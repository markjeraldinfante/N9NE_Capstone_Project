using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScoreDisplay : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject endScreen;
    public GameObject soundHolder;

    void Start()
    {
        ObstacleCollision.endGame += EndScreens;
    }
    private void OnDestroy()
    {
        ObstacleCollision.endGame -= EndScreens;
    }
    public void EndScreens()
    {
        soundHolder.SetActive(false);
        disDisplay.SetActive(false);
        endScreen.SetActive(true);

    }



}
