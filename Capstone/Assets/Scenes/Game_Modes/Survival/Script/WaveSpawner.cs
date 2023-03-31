using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class WaveSpawner : MonoBehaviour
{
    public GameObject panel, waveNumberobj;
    [SerializeField] private baseSurvivalVariant variant;
    public GameObject enemyPrefab;
    public Transform spawnPoints1;
    Vector3 spawnPointsRandom;
    public Transform spawnPoints2;
    public float timeBetweenWaves = 10f;
    private float countdown = 5f;
    public GameObject enemyTrans;
    public Transform targetEnemy;
    public TextMeshProUGUI waveNumbertext;
    public TextMeshProUGUI waveCountdownText;
    [PunRPC] public int currentEnemy;
    [PunRPC] private int waveNumber = 0;
    PhotonView photonView;

    private bool isCountdownFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy == 0)
        {
            if (isCountdownFinished)
            {
                panel.SetActive(false);
                waveNumberobj.SetActive(false);
                waveCountdownText.gameObject.SetActive(false);
                StartCoroutine(Spawnwave());
                waveNumbertext.text = "Wave: " + waveNumber.ToString();
                countdown = timeBetweenWaves;
                isCountdownFinished = false;
            }
            else
            {
                panel.SetActive(true);
                waveNumberobj.SetActive(true);
                countdown -= Time.deltaTime;
                waveCountdownText.text = Mathf.Round(countdown).ToString();
                if (countdown <= 0f)
                {
                    isCountdownFinished = true;
                }
            }
        }
    }

    [PunRPC]
    void UpdateCurrentEnemy(int enemyCount)
    {
        currentEnemy = enemyCount;
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
            if (PhotonNetwork.IsMasterClient)
            {
                enemyTrans = PhotonNetwork.Instantiate(enemyPrefab.name, spawnPointsRandom, spawnPoints1.rotation);
                currentEnemy++;
            }
        }
        else if (variant.variantType != baseSurvivalVariant.VariantType.Online)
        {
            enemyTrans = Instantiate(enemyPrefab, spawnPointsRandom, spawnPoints1.rotation);
            currentEnemy++;
        }
    }

    public void KilledEnemy()
    {
        if (variant.variantType == baseSurvivalVariant.VariantType.Online)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView = GetComponent<PhotonView>();
                currentEnemy--;
                photonView.RPC("UpdateCurrentEnemy", RpcTarget.All, currentEnemy);
            }
        }
        else if (variant.variantType != baseSurvivalVariant.VariantType.Online) { currentEnemy--; }
    }
}
