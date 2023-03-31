using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
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
    private void Awake()
    {
        if (forPlayer)
        {
            Debug.Log("Searching for GameHUD object...");
            GameObject gameHUDObject = GameObject.FindGameObjectWithTag("GameHUD");
            if (gameHUDObject != null && gameHUDObject.activeSelf)
            {

                cacheGameHUD = gameHUDObject.transform;
                gameHUD = cacheGameHUD.gameObject;
                healthBar = gameHUD.GetComponentInChildren<HealthBar>();
                damageOverlay = gameHUD.GetComponent<DamageOverlay>();
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

}


