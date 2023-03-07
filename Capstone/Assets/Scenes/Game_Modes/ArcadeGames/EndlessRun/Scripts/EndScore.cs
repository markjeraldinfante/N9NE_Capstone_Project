using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScore : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    public void RestartButton()
    {
        SceneManager.LoadScene("EndlessGame");
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("EndlessMainMenu");
    }
}
