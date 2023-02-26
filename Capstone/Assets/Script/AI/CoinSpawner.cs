using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnPoints;
    public int coinsPerSpawn;
    public bool isCleared;

    private HashSet<Vector3> usedPositions = new HashSet<Vector3>();

    private void Awake()
    {
        if (!isCleared) { SpawnCoins(); }
        else
            return;
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinsPerSpawn; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;

            while (usedPositions.Contains(spawnPosition)) // Keep generating new spawn position until it's not already used
            {
                randomIndex = Random.Range(0, spawnPoints.Length);
                spawnPosition = spawnPoints[randomIndex].position;
            }

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            usedPositions.Add(spawnPosition); // Add the new spawn position to the set of used positions
        }
    }
}
