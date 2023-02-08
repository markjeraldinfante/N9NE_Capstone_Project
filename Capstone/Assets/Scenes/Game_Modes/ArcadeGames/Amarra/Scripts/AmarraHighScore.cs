using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmarraHighScore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    void Start()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefKeys.AMARRA_HSCORE))
        {
            highscoreText.text = ("Highscore: " + 0);
        }
        else
        {

            highscoreText.text = ("Highscore: " + PlayerPrefs.GetInt(PlayerPrefKeys.AMARRA_HSCORE));

        }
        Debug.Log(PlayerPrefs.GetInt(PlayerPrefKeys.AMARRA_HSCORE));
    }

}
