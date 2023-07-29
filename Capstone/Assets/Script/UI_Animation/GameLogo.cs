using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogo : MonoBehaviour
{
    [SerializeField] private float delayTime = 2.0f;
    void Start()
    {
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {

        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(1);
    }
}
