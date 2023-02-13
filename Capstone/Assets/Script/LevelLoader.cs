using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject[] objectsToHide = null;
    public void LoadLevel(int sceneIndex)
    {
        HideObjects();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    private void HideObjects()
    {
        if (objectsToHide == null) return;
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneIndex);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
