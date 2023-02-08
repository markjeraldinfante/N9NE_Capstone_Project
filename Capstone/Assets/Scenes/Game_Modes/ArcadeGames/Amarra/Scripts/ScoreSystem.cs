using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float totalScore;
    public float scorePoints;
    [SerializeField] int intScore;
    public TextMeshProUGUI scoreText;
    [SerializeField] private AmarraMovement amarraMovement;
    public GameObject amarraManager;
    public AmarraManager1 SOAmarra;
    public int AwardCount;




    void Start()
    {

        totalScore = 0f;
        scorePoints = 1f;
        SOAmarra.HighScore.ToString("Highscore: " + "0");
    }
    public void Update()
    {
        totalScore += scorePoints * Time.deltaTime;
        SOAmarra.score = (int)totalScore;
        scoreText.text = "Score: " + SOAmarra.score.ToString("0");
        AwardUpdater();
        HighScoreUpdate();
    }
    public void HighScoreUpdate()
    {
        var gameSystem = new GameSystem();
        int highScore = gameSystem.Load(PlayerPrefKeys.AMARRA_HSCORE);
        int currentScore = SOAmarra.score;

        if (currentScore > highScore)
        {
            gameSystem.Save(currentScore, PlayerPrefKeys.AMARRA_HSCORE);
            SOAmarra.HighScore = currentScore;
        }

    }
    public void awardSystem(GameObject awardUI, GameObject gameoverUI)
    {


        if (SOAmarra.score <= 19)
        {
            // AwardCount = SOAmarra.tansoAward;
            gameoverUI.SetActive(true);
        }
        if (SOAmarra.score >= 20)
        {
            // AwardCount = SOAmarra.tansoAward;
            awardUI.SetActive(true);
        }
        if (SOAmarra.score >= 40)
        {
            //  AwardCount = SOAmarra.tansoAward;
            awardUI.SetActive(true);

        }
        if (SOAmarra.score >= 60)
        {
            // AwardCount = SOAmarra.tansoAward;
            awardUI.SetActive(true);

        }
        if (SOAmarra.score >= 80)
        {
            /// AwardCount = SOAmarra.tansoAward;
            awardUI.SetActive(true);

        }
        if (SOAmarra.score >= 100)
        {
            // AwardCount = SOAmarra.tansoAward;
            awardUI.SetActive(true);

        }


    }

    void AwardUpdater()
    {
        if (SOAmarra.score <= 19)
        {
            SOAmarra.tansoAward = 0;
        }
        if (SOAmarra.score >= 20)
        {
            SOAmarra.tansoAward = 1;
        }
        if (SOAmarra.score >= 40)
        {
            SOAmarra.tansoAward = 3;
        }
        if (SOAmarra.score >= 60)
        {
            SOAmarra.tansoAward = 5;
        }
        if (SOAmarra.score >= 80)
        {
            SOAmarra.tansoAward = 7;
        }
        if (SOAmarra.score >= 100)
        {
            SOAmarra.tansoAward = 9;
        }
    }

    //lilipat sa manager
    public void SaveTanso(int totalTanso)
    {
        var gameSystem = new GameSystem();
        SOAmarra.TotalAward += totalTanso;
        gameSystem.Save(SOAmarra.TotalAward, PlayerPrefKeys.TANSO);
    }


}
