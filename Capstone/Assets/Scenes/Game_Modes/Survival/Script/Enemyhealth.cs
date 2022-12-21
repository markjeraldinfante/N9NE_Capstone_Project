using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public WaveSpawner wave;
    public GameObject enemyGameboject;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        wave = GameObject.Find("WaveManager (2)").GetComponent<WaveSpawner>();
        enemyGameboject = wave.enemyTrans;

    }

    void Update()
    {
        if (currentHealth <= 0) { Destroy(enemyGameboject); }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bato") { TakeDamage(20); }
    }
}
