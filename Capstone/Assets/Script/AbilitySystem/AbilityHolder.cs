using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public Ability[] abilities;
    float[] cooldownTimes;
    float[] activeTimes;
    private Animator animator;
    private IEnumerator coroutine;
    public Image[] cds;
    public Button skillButton;
    bool triggered = false;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState[] states;
    public KeyCode[] keys;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
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
                    if (Input.GetKeyDown(keys[i]) && !playerController.isProne || triggered)
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
                        if (abilities[i] is MoveSpeed_Ability)
                        {
                            playerController.runSpeed = 2.5f + ((MoveSpeed_Ability)abilities[i]).movementSpeed;
                        }
                    }
                    else
                    {
                        abilities[i].BeginCooldown(gameObject);
                        states[i] = AbilityState.cooldown;
                        cooldownTimes[i] = abilities[i].cooldownTime;
                        if (abilities[i] is MoveSpeed_Ability)
                        {
                            playerController.runSpeed = 2.5f; // set back to original speed
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
        abilities[abilityIndex].Activate(gameObject);

    }
}
