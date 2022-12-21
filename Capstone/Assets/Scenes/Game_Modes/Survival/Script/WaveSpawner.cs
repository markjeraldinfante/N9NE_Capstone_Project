using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform spawnPoints1;
    Vector3 spawnPointsRandom;
    public Transform spawnPoints2;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public GameObject enemyTrans;
    public Transform targetEnemy;
    public TextMeshProUGUI waveNumbertext;
    public TextMeshProUGUI waveCountdownText;

    private int waveNumber = 0;


    // Update is called once per frame
    void Update()
    {
        // Start();
        if (countdown <= 0f)
        {
            StartCoroutine(Spawnwave());
            waveNumbertext.text = "Wave: " + waveNumber.ToString();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = string.Format("{0:00.00}", countdown);

    }

    IEnumerator Spawnwave()
    {

        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }




    }
    public void SpawnEnemy()
    {
        enemyTrans = enemyPrefab;
        enemyPrefab.GetComponent<ENEMY1>().target = targetEnemy;
        spawnPointsRandom = new Vector3
        (
        Random.Range(spawnPoints1.position.x, spawnPoints2.position.x),
        Random.Range(spawnPoints1.position.y, spawnPoints2.position.y),
        Random.Range(spawnPoints1.position.z, spawnPoints2.position.z)
        );
        enemyTrans = Instantiate(enemyPrefab, spawnPointsRandom, spawnPoints1.rotation);

    }

}
