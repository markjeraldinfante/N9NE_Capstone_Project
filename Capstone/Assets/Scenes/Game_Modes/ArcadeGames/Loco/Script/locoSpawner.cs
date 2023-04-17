using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locoSpawner : MonoBehaviour
{
    [SerializeField]
    private int IntScore;
    private float score;
    public float startTimeSpawn;
    private float timeSpawn;
    public GameObject[] enemies;
    public float timeDecreasePerSecond;
    public float minSpawnDistance;
    private GameObject lastSpawnedEnemy;

    void Start()
    {
        minSpawnDistance = Mathf.Max(minSpawnDistance, 2f); // setting a minimum value
        startTimeSpawn = Mathf.Max(startTimeSpawn, 0.5f);   // setting a minimum value
    }

    private void Update()
    {
        if (timeSpawn <= 0)
        {
            int rand = Random.Range(0, enemies.Length);
            Vector3 spawnPosition = transform.position;
            minSpawnDistance -= 0.1f * startTimeSpawn; // changing the minimum spawn distance
            minSpawnDistance = Mathf.Max(minSpawnDistance, 2f); // setting a minimum value
            // Check distance to previously spawned enemy
            if (lastSpawnedEnemy != null && Vector3.Distance(lastSpawnedEnemy.transform.position, spawnPosition) < minSpawnDistance)
            {
                // Move spawn position if too close to previous enemy
                Vector3 offset = spawnPosition - lastSpawnedEnemy.transform.position;
                offset.Normalize();
                spawnPosition += offset * minSpawnDistance;
            }

            Instantiate(enemies[rand], spawnPosition, Quaternion.identity);
            lastSpawnedEnemy = enemies[rand];
            timeSpawn = startTimeSpawn;
            startTimeSpawn -= timeDecreasePerSecond * Time.deltaTime;
            startTimeSpawn = Mathf.Clamp(startTimeSpawn, 0.5f, startTimeSpawn); // ensuring that startTimeSpawn never goes below 0.5f
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }

        GetScore();
    }


    public int GetScore()
    {
        IntScore = Mathf.RoundToInt(score += Time.deltaTime);
        return IntScore;
    }
}
