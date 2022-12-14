using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locoSpawner : MonoBehaviour
{
    public float startTimeSpawn;
    private float timeSpawn;
    public GameObject[] enemies;

    private void Update()
    {
        if (timeSpawn <= 0)
        {
            int rand = Random.Range(0, enemies.Length);
            Instantiate(enemies[rand], transform.position, Quaternion.identity);
            timeSpawn = startTimeSpawn;
        }

        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}
