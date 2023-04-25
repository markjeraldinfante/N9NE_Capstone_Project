using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmarraManager : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject gameawardUI;


    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }


        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void pGame()
    {
        Pause();
    }
}
