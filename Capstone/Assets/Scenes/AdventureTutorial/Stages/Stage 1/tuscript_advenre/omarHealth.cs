using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class omarHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(int damage)
    {
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
        }
    }
}
