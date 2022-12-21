using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public void Start()
    {
        tutorialCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnDisable()
    {
        tutorialCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
