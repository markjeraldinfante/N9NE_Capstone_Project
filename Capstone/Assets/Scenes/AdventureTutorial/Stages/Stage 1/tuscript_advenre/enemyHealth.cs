using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
private string currentState;
   //  public int health;
      public int maxHealth;
    public int currentHealth;
    public Animator animator;
   // public HealthBar healthBar;
  //  public Enemy_Carp enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
         currentHealth = maxHealth;
       // healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void TakeDamage(int damage)
    {
        currentHealth -= damage;
      //  enemyMovement.speed = 0.01f;
       // healthBar.SetHealth(currentHealth);
        currentHealth -= damage;
        currentState = "ChaseState";

        if(currentHealth < 0)
        {
            Die();
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bato") { TakeDamage(10); DestroyWithTag("Bato");
        //somnium.SoundManager.instance.PlaySFX("AguyMobs"); 
        }
        // else StartCoroutine(NormalSpeed());
    }
     IEnumerator NormalSpeed()

    {
        yield return new WaitForSeconds(5f);
      //  enemyMovement.speed = 0.05f;
    }
     void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
 private void Die()
    {
        //play a die animation
        animator.SetTrigger("isDead");

        //disable the script and the collider
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 3);
        this.enabled = false;
    }
}
