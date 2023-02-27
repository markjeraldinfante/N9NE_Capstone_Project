using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameoverscreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void Setup(int scores)
    {
        gameObject.SetActive(true);
        pointsText.text = scores.ToString() + " Tanso";

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("junkshop");
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
