using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCounterText;
    private List<GameObject> enemies;
    [SerializeField] private int enemyCount;
    private bool isEnemyDeath;

    void Start()
    {
        isEnemyDeath = false;
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
        enemyCount = enemies.Count;
    }

    void Update()
    {

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
                enemyCount--;
            }
        }
        if (enemyCount <= 0)
        {
            Debug.Log("All enemies have been destroyed!");
            isEnemyDeath = true;
        }
        enemyCounterText.text = "Enemy: " + enemyCount.ToString();
    }
    public bool GetEnemyState()
    {
        return isEnemyDeath;
    }
}
