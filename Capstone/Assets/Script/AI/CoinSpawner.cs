using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnPoints;
    public int coinsPerSpawn;
    [SerializeField] private LevelBase level;
    private HashSet<Vector3> usedPositions = new HashSet<Vector3>();

    private void Awake()
    {
        if (!level.isCleared) { SpawnCoins(); }
        else
            return;
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinsPerSpawn; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;

            while (usedPositions.Contains(spawnPosition))
            {
                randomIndex = Random.Range(0, spawnPoints.Length);
                spawnPosition = spawnPoints[randomIndex].position;
            }

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.gameObject.transform);
            usedPositions.Add(spawnPosition);
        }
    }
}
