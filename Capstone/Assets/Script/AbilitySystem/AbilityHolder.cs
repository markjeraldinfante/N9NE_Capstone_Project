using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public GameObject shieldParticle, healParticle;
    private GameObject character;
    Transform characterCache;
    [SerializeField] PlayerController playerController;
    [SerializeField] EntityHealth entityHealth;
    public Ability[] abilities;
    float[] cooldownTimes;
    float[] activeTimes;
    private Animator animator;
    private IEnumerator coroutine;
    public Image[] cds;
    public Button skillButton;
    bool triggered = false;
    DamageOverlay damageOverlay;
    Rigidbody rb;


    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState[] states;
    // public KeyCode[] keys;
    public string[] buttons = { "Skill1", "Skill2", "Skill3", "Skill4" };
    private void Start()
    {

        //Player Component
        characterCache = GameObject.FindGameObjectWithTag("Player").transform;
        character = characterCache.gameObject;
        shieldParticle = characterCache.Find("ShieldSpawn").gameObject;
        healParticle = characterCache.Find("HealSpawn").gameObject;
        animator = character.GetComponent<Animator>();
        playerController = character.GetComponent<PlayerController>();
        rb = character.GetComponent<Rigidbody>();
        entityHealth = character.GetComponent<EntityHealth>();

        damageOverlay = gameObject.GetComponent<DamageOverlay>();
        states = new AbilityState[abilities.Length];
        cooldownTimes = new float[abilities.Length];
        activeTimes = new float[abilities.Length];
        for (int i = 0; i < abilities.Length; i++)
        {
            states[i] = AbilityState.ready;
        }
    }

    public void onSkillTrigger()
    {
        triggered = true;
    }

    public void Update()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            switch (states[i])
            {
                case AbilityState.ready:
                    if (Input.GetButtonDown(buttons[i]) && !playerController.isProne || triggered)
                    {
                        cds[i].fillAmount = 1f;
                        coroutine = WaitAndPrint(i, .5f);
                        StartCoroutine(coroutine);

                        states[i] = AbilityState.active;
                        activeTimes[i] = abilities[i].activeTime;
                    }
                    break;

                case AbilityState.active:
                    if (activeTimes[i] > 0)
                    {
                        activeTimes[i] -= Time.deltaTime;
                        cds[i].fillAmount = 0f;
                        if (abilities[i] is Charge_Ability)
                        {
                            animator.SetBool("Dash", true);
                            rb.constraints |= RigidbodyConstraints.FreezePositionY;
                        }
                        if (abilities[i] is MoveSpeed_Ability)
                        {
                            playerController.runSpeed = 3f + ((MoveSpeed_Ability)abilities[i]).movementSpeed;
                        }
                        if (abilities[i] is Heal_Ability)
                        {
                            healParticle.SetActive(true);
                            damageOverlay.Healing(((Heal_Ability)abilities[i]).healDuration);
                            //entityHealth.currentHealth += ((Heal_Ability)abilities[i]).healAmount;
                        }
                        if (abilities[i] is Shield_Ability)
                        {
                            if (entityHealth.isInvulnerable)
                            {
                                shieldParticle.SetActive(true);
                            }

                        }
                    }
                    else
                    {
                        abilities[i].BeginCooldown(character);
                        states[i] = AbilityState.cooldown;
                        cooldownTimes[i] = abilities[i].cooldownTime;
                        if (abilities[i] is Charge_Ability)
                        {
                            animator.SetBool("Dash", false);
                            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;

                        }
                        if (abilities[i] is MoveSpeed_Ability)
                        {
                            playerController.runSpeed = 3f; // set back to original speed
                        }
                        if (abilities[i] is Heal_Ability)
                        {
                            healParticle.SetActive(false);
                        }
                        if (abilities[i] is Shield_Ability)
                        {
                            entityHealth.isInvulnerable = false;
                            shieldParticle.SetActive(false);
                        }
                    }
                    break;


                case AbilityState.cooldown:
                    if (cooldownTimes[i] > 0)
                    {
                        cooldownTimes[i] -= Time.deltaTime;
                        cds[i].fillAmount = 1f - cooldownTimes[i] / abilities[i].cooldownTime;
                    }
                    else
                    {
                        triggered = false;
                        states[i] = AbilityState.ready;

                    }
                    break;
            }
        }
    }

    private IEnumerator WaitAndPrint(int abilityIndex, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        abilities[abilityIndex].Activate(character);

    }
}
