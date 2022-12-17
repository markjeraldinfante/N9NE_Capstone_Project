using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class popUp : MonoBehaviour
{
    public GameObject raylight;
    public TextMeshProUGUI awardName;
    public Image awardImage;
    public int loopTime = 2;
    public Button playagainButton;
    public Button backButton;

    void OnEnable()
    {
        LeanTween.cancel(raylight);
        LeanTween.rotateAround(raylight, Vector3.back, 360f, loopTime).setLoopClamp().setIgnoreTimeScale(true);
    }
    private void OnDisable()
    {
        LeanTween.cancel(raylight);
    }
    public void playAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
