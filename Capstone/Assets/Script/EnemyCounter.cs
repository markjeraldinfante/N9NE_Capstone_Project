using UnityEngine;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour
{
    private List<GameObject> enemies; // a list of enemy GameObjects to be tracked
    [SerializeField] private int enemyCount; // a counter to keep track of how many enemies are left

    void Start()
    {
        // find all GameObjects in the scene with the "Enemy" tag and add them to the list
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
        enemyCount = enemies.Count; // initialize the enemy count to the number of enemies in the list
    }

    void Update()
    {
        // check if any enemies in the list have been destroyed
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
                enemyCount--; // decrease the enemy count when an enemy is destroyed
            }
        }

        // check if all enemies have been destroyed
        if (enemyCount <= 0)
        {
            Debug.Log("All enemies have been destroyed!");
        }
    }
}
