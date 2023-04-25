using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePause : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen = null;
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject[] objectsToHide = null;
    public GameObject pauseMenuUI;
    private void Awake()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void HideObjects()
    {
        if (objectsToHide == null) return;

        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }
    private void ShowObjects()
    {
        if (objectsToHide == null) return;

        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }
    }
    public void Resume()
    {
        ShowObjects();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        HideObjects();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        HideObjects();
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously(2));

    }
    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneIndex);
    }

}
