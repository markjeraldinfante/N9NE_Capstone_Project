using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AwardSystem : MonoBehaviour
{
    [SerializeField] private MiniGameManager litexManager;
    public int coinAward;
    DistanceDisplay distance;
    public TextMeshProUGUI coinCount;
    private void Awake()
    {
        distance = GetComponent<DistanceDisplay>();
    }
    private void Start()
    {
        // Initialize the tansoAward to 0
        litexManager.tansoAward = 0;
    }
    private void OnEnable()
    {
        ObstacleCollision.endGame += SaveTanso;
    }
    private void OnDisable()
    {
        ObstacleCollision.endGame -= SaveTanso;
    }

    // Update is called once per frame
    void Update()
    {
        // Instead of multiple if statements, use a switch statement to check the distance
        switch (distance.disRun)
        {
            case >= 4000:
                coinAward = 6;
                break;
            case >= 2000:
                coinAward = 5;
                break;
            case >= 1000:
                coinAward = 4;
                break;
            case >= 500:
                coinAward = 3;
                break;
            case >= 200:
                coinAward = 2;
                break;
            case >= 100:
                coinAward = 1;
                break;
            default:
                coinAward = 0;
                break;
        }

        litexManager.tansoAward = coinAward;
        coinCount.text = coinAward.ToString();
    }

    public void SaveTanso()
    {
        // Use a singleton pattern to get the GameSystem instance
        var gameSystem = new GameSystem();
        litexManager.TotalAward += litexManager.tansoAward;
        gameSystem.Save(litexManager.TotalAward, PlayerPrefKeys.TANSO);
    }

}
