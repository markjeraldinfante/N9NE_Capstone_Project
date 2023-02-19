using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class omarHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(int damage)
    {
        healthBar.SetHealth(currentHealth);
        currentHealth -= damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pamalo")
        {
            TakeDamage(10);
            
        }
        if(other.gameObject.tag == "fallobj")
        {
            TakeDamage(50);
            DestroyWithTag("fallobj");
        }

    }
    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
}
