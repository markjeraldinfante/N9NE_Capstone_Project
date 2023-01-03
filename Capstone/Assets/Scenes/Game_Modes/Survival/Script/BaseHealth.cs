using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pamalo") { TakeDamage(5); }
    }
}
