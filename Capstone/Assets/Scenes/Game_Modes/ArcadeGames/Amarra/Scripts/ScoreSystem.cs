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



    void Start()
    {
        scoreAmount = 0f;
        scoreP = 1f;
        PlayerPrefs.GetFloat("AmarraHighscore").ToString("Highscore: " + "0");
    }
    public void Update()
    {


        scoreAmount += scoreP * Time.deltaTime;
        //amarraMovement.tansoAward = intScore;
        SOAmarra.score = (int)scoreAmount;
        scoreText.text = "Score: " + SOAmarra.score.ToString("0");

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
            SOAmarra.tansoAward = 0;
            gameoverUI.SetActive(true);
        }
        if (SOAmarra.score >= 20)
        {
            SOAmarra.tansoAward = 1;
            awardUI.SetActive(true);
        }
        if (SOAmarra.score >= 40)
        {
            SOAmarra.tansoAward = 3;
            awardUI.SetActive(true);
        }
        if (SOAmarra.score >= 60)
        {
            SOAmarra.tansoAward = 5;
            awardUI.SetActive(true);
        }
        if (SOAmarra.score >= 80)
        {
            SOAmarra.tansoAward = 7;
            awardUI.SetActive(true);
        }
        if (SOAmarra.score >= 100)
        {
            SOAmarra.tansoAward = 9;
            awardUI.SetActive(true);
        }


    }


}
