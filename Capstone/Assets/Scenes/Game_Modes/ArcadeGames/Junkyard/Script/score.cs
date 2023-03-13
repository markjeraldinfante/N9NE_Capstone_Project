using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public gameoverscreen gameoverscreen;
    public MiniGameManager junkYard;
    private int Score;
    public GameObject groundObj;
    public GameObject scoreTextObj;

    public void Start()
    {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverscreen.Setup(Score);

    }

    void Update()
    {
        scoreText.text = "Score: " + Score;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "scrap")
        {
            Destroy(target.gameObject);
            this.gameObject.SetActive(false);
            groundObj.SetActive(false);
            scoreTextObj.SetActive(false);
            GameOver();
        }

    }
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "bcoin")
        {
            // audioBcoin.Play();
            Destroy(target.gameObject);
            Score++;

            SaveTanso(Score);
        }
    }
    public void SaveTanso(int scores)
    {
        var gameSystem = new GameSystem();
        junkYard.tansoAward += scores;
        gameSystem.Save(junkYard.tansoAward, PlayerPrefKeys.BROKEN_TANSO);
    }

}
