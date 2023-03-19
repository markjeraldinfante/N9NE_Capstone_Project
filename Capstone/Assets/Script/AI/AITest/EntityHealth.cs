using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    DamageOverlay damageOverlay;
    private void Awake()
    {
        damageOverlay = GameObject.FindGameObjectWithTag("GameHUD").GetComponent<DamageOverlay>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        damageOverlay.ShowDamage(damageAmount);
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


