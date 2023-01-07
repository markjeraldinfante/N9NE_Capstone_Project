using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float scoreAmount;
    public float scoreP;
    [SerializeField] int intScore;
    public TextMeshProUGUI scoreText;
    [SerializeField] private AmarraMovement amarraMovement;
    public GameObject amarraManager;
    public AmarraManager1 SOAmarra;
    public int AwardCount;



    void Start()
    {
        SOAmarra.tansoAward = 0;
        scoreAmount = 0f;
        scoreP = 1f;
        PlayerPrefs.GetFloat("AmarraHighscore").ToString("Highscore: " + "0");
    }
    public void Update()
    {
        scoreAmount += scoreP * Time.deltaTime;
        SOAmarra.score = (int)scoreAmount;
        scoreText.text = "Score: " + SOAmarra.score.ToString("0");
        AwardUpdater();
        if (SOAmarra.score > PlayerPrefs.GetInt("AmarraHighscore"))
        {
            PlayerPrefs.SetInt("AmarraHighscore", SOAmarra.score);
            scoreAmount.ToString("AmarraHighscore: " + "0");
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

}
