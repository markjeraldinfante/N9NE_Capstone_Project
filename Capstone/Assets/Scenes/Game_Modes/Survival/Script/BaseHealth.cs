using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BaseHealth : MonoBehaviour
{
   
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public string GameOverScreen;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(GameOverScreen);
        }
    }


    /* public void GameOver()
      {
          if (currentHealth <= 0)
          {
              gameover_survival.Setup();
          }
      }
    */
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
