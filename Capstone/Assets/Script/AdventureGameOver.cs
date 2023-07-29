using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AdventureGameOver : MonoBehaviour
{

    public float delayTime;
    public Image overlay;
    public float fadeTime = 0.5f;
    public Color fadeColor = new Color(0, 0, 0, 1); // Transparent black color

    private void OnEnable()
    {

        EntityHealth.characterIsDead += GameOverScene;

    }

    private void OnDestroy()
    {

        EntityHealth.characterIsDead -= GameOverScene;

    }


    private void GameOverScene()
    {
        LeanTween.reset();
        // Show the overlay
        overlay.gameObject.SetActive(true);

        // Fade the overlay to black
        LeanTween.alpha(overlay.rectTransform, fadeColor.a, fadeTime)
                 .setEase(LeanTweenType.easeOutSine)
                 .setOnComplete(LoadScene);
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(33);
    }
}
