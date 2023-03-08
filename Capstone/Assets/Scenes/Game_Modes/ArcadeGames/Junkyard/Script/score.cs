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
    public AudioSource audioBcoin;

    private int Score = 0;

    // Start is called before the first frame update
    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverscreen.Setup(Score);

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.ToString();
    }

     void OnTriggerEnter2D(Collider2D target) 
    { 
        if (target.tag == "scrap")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
            GameOver();
        }
        
    }
     void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "bcoin")
        {
            audioBcoin.Play();
            Destroy(target.gameObject);
            Score++;
        }
    }

    
}
