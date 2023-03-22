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
    DamageOverlay damageOverlay;
    [SerializeField] private bool forPlayer;
    public bool isInvulnerable;
    private void Awake()
    {
        if (forPlayer)
        {
            cacheGameHUD = GameObject.FindGameObjectWithTag("GameHUD").transform;
            healthBar = GameObject.FindGameObjectWithTag("PlayerHealthbar").GetComponent<HealthBar>();
            gameHUD = cacheGameHUD.gameObject;
            damageOverlay = gameHUD.GetComponent<DamageOverlay>();
        }
        else
        {
            damageOverlay = null;
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

    private void Die(Animator animator)
    {

        animator.SetTrigger("isDead");
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 3);
        this.enabled = false;
        GetComponent<enemy_adventure>().enabled = false;

    }

}


