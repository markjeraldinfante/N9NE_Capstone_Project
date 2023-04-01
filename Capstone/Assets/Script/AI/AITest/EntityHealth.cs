using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EntityHealth : MonoBehaviour
{
    [SerializeField] private basePlayerSelect playerSelect;
    public delegate void CharacterIsDead();
    public static event CharacterIsDead characterIsDead;
    public event System.Action OnDeath;
    GameObject gameHUD;
    Transform cacheGameHUD;
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public DamageOverlay damageOverlay;
    [SerializeField] private bool forPlayer;
    public bool isInvulnerable;
    GameObject gameHUDObject;
    Slider lifeSlider;
    Image lifeColor;
    private void Awake()
    {
        if (forPlayer)
        {
            Debug.Log("Searching for GameHUD object...");
            gameHUDObject = GameObject.FindGameObjectWithTag("GameHUD");
            if (gameHUDObject != null && gameHUDObject.activeSelf)
            {

                cacheGameHUD = gameHUDObject.transform;
                gameHUD = cacheGameHUD.gameObject;
                healthBar = gameHUD.GetComponentInChildren<HealthBar>();
                lifeSlider = healthBar.getSlider();
                damageOverlay = gameHUD.GetComponent<DamageOverlay>();
                lifeColor = lifeSlider.fillRect.GetComponent<Image>();
                Debug.Log("damageOverlay assigned: " + damageOverlay);
                Debug.Log("healthBar assigned: " + healthBar);
            }
            else
            {
                Debug.LogError("GameHUD object not found or is inactive!");
            }
        }

    }


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (forPlayer)
        {
            if (currentHealth >= 80f)
            {
                lifeColor.color = Color.green;
            }
            else if (currentHealth >= 60f)
            {
                // Yellowish orange
                lifeColor.color = new Color(1f, 0.93f, 0f, 1f);
            }
            else if (currentHealth >= 30f)
            {
                // Red orange
                lifeColor.color = new Color(1f, 0.50f, 0f, 1f);
            }
            else
            {
                lifeColor.color = Color.red;
            }
        }

    }


    public void TakeDamage(float damageAmount)
    {
        if (forPlayer)
        {
            if (isInvulnerable) { return; }
            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);
            damageOverlay.ShowDamage(damageAmount);
            if (currentHealth <= 0)
            {
                characterIsDead?.Invoke();

            }
        }
        else
        {
            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (OnDeath != null)
                {
                    OnDeath();
                }
            }
        }
    }

    public void Die(Animator anim, GameObject obj, float destroyTime)
    {
        BossScript bossScript = GetComponent<BossScript>();
        anim.SetBool("isDead", true);
        Destroy(obj, destroyTime);
        this.enabled = false;

    }
    void SoundChecker()
    {
        if (playerSelect.CharacterID == "1")
        {

            somnium.SoundManager.instance.PlaySFX("OmarDamageReceive");
            return;
        }

        if (playerSelect.CharacterID == "2")
        {

            somnium.SoundManager.instance.PlaySFX("JunnieDamageReceive");
            return;
        }
        if (playerSelect.CharacterID == "3")
        {

            somnium.SoundManager.instance.PlaySFX("RicoDamageReceive");
            return;
        }
        if (playerSelect.CharacterID == "4")
        {

            // somnium.SoundManager.instance.PlaySFX("AzuleDeath");
            return;
        }

    }
    private IEnumerator PlaySoundPeriodically(float interval)
    {
        while (true)
        {
            SoundChecker();
            yield return new WaitForSeconds(interval);
        }
    }

    // Call this function to start playing the sound every second
    private void StartPlayingSound()
    {
        StartCoroutine(PlaySoundPeriodically(1f));
    }

    // Call this function to stop playing the sound
    private void StopPlayingSound()
    {
        StopCoroutine(PlaySoundPeriodically(1f));
    }


}


