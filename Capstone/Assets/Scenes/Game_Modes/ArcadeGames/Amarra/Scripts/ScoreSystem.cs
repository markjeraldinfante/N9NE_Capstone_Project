using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float scoreAmount;
    public float scoreP;
    public TextMeshProUGUI scoreText;



    void Start()
    {

        scoreAmount = 0f;
        scoreP = 1f;
        PlayerPrefs.GetFloat("AmarraHighscore").ToString("Highscore: " + "0");
    }
    void Update()
    {


        scoreAmount += scoreP * Time.deltaTime;
        scoreText.text = "Score: " + scoreAmount.ToString("0");

        if (scoreAmount > PlayerPrefs.GetFloat("AmarraHighscore", 0))
        {
            PlayerPrefs.SetFloat("AmarraHighscore", scoreAmount);
            scoreAmount.ToString("AmarraHighscore: " + "0");
        }

    }


}
