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
    public ENEMY1 enemyMovement;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        wave = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveSpawner>();
        enemyGameboject = wave.enemyTrans;
    }

    void Update()
    {
        if (currentHealth <= 0) { Destroy(enemyGameboject); wave.KilledEnemy(); }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyMovement.speed = 0.01f;
        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bato") { TakeDamage(10); DestroyWithTag("Bato"); }
        if (other.gameObject.tag == "Pamalo") { TakeDamage(15); Debug.Log("Nahampas"); }
        // else StartCoroutine(NormalSpeed());
    }

    IEnumerator NormalSpeed()

    {
        yield return new WaitForSeconds(5f);
        enemyMovement.speed = 0.05f;
    }

    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
}
