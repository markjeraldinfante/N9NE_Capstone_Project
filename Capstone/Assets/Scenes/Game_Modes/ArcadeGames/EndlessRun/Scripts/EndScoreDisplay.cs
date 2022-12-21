using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScoreDisplay : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject endScreen;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndScreens());
    }
    IEnumerator EndScreens()
    {
        yield return new WaitForSeconds(3);
        disDisplay.SetActive(false);
        endScreen.SetActive(true);
        //yield return new WaitForSeconds(3);
        //fadeOut.SetActive(true);
    }



}
