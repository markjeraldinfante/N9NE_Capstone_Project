using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScoreDisplay : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject endScreen;
    public GameObject fadeOut;
    public GameObject player;
    public GameObject levelControls;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndScreens());
    }
    IEnumerator EndScreens()
    {
        yield return new WaitForSeconds(0);
        disDisplay.SetActive(false);
        player.GetComponent<Animator>().enabled = false;
        levelControls.GetComponent<GeneratingLevel>().enabled = false;
        endScreen.SetActive(true);
        //yield return new WaitForSeconds(3);
        //fadeOut.SetActive(true);
    }



}
