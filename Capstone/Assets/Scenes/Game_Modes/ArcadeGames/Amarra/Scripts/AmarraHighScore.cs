using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmarraHighScore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public MiniGameManager SOAmarra;
    void Awake()
    {
        var gameSystem = new GameSystem();
        highscoreText.text = ("Highscore: " + gameSystem.Load(PlayerPrefKeys.AMARRA_HSCORE));
    }

}
