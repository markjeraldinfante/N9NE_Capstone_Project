using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmarraHighScore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    void Start()
    {
        if (!PlayerPrefs.HasKey("AmarraHighscore"))
        {
            highscoreText.text = ("Highscore: " + 0);
        }
        else
        {

            highscoreText.text = ("Highscore: " + PlayerPrefs.GetInt("AmarraHighscore"));

        }
        Debug.Log(PlayerPrefs.GetInt("AmarraHighscore"));
    }

}
