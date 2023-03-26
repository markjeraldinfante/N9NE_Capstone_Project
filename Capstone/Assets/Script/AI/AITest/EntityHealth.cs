using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
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
        }
        else
        {
            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Die(Animator anim)
    {
        BossScript bossScript = GetComponent<BossScript>();
        anim.SetBool("isDead", true);
        bossScript.enabled = false;
        // anim.SetTrigger("isDead");
        GetComponent<CapsuleCollider>().enabled = true;
        Destroy(gameObject, 1);
        this.enabled = false;

    }

}


