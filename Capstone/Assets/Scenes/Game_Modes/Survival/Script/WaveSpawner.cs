using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variant;
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
    public int currentEnemy;
    private int waveNumber = 0;


    // Update is called once per frame
    void Update()
    {
        if (currentEnemy == 0)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(Spawnwave());
                waveNumbertext.text = "Wave: " + waveNumber.ToString();
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;
            waveCountdownText.text = string.Format("{0:00.00}", countdown);
        }
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
        if (variant.variantType == baseSurvivalVariant.VariantType.Online)
        {
            enemyTrans = PhotonNetwork.Instantiate(enemyPrefab.name, spawnPointsRandom, spawnPoints1.rotation);
            currentEnemy++;
            return;
        }
        else
        {
            enemyTrans = Instantiate(enemyPrefab, spawnPointsRandom, spawnPoints1.rotation);
            currentEnemy++;
        }
    }


}
