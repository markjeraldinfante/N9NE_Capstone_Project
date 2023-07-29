using System.Collections;
using UnityEngine;
using TMPro;

public class GameCountdown : MonoBehaviour
{
    public float timeLeft = 5.0f;
    public TextMeshProUGUI countdownText;
    public GameObject countObject;
    public GameObject scoreText;
    public GameObject soundHolder;
    private void Awake()
    {
        PauseGame();

    }
    private void Start()
    {

        StartCoroutine(Countdown());
    }

    private void PauseGame()
    {
        scoreText.SetActive(false);
        soundHolder.SetActive(false);
        Time.timeScale = 0;
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            countdownText.text = Mathf.Round(timeLeft).ToString();
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
        }
        countdownText.text = "Go!";
        scoreText.SetActive(true);
        soundHolder.SetActive(true);
        Time.timeScale = 1;
        countObject.SetActive(false);
    }
}
