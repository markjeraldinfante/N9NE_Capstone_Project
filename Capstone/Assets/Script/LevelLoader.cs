using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen = null;
    [SerializeField] private baseSurvivalVariant variant = null;
    [SerializeField] private GameObject[] objectsToHide = null;

    public void SurvivalLoad()
    {
        int indexOffline = 8;
        int indexOnline = 6;
        HideObjects();
        StartCoroutine(LoadAsynchronously(variant.mode == baseSurvivalVariant.GameMode.Online ? indexOnline : indexOffline));
    }

    public void LoadLevel(int sceneIndex)
    {
        HideObjects();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private void HideObjects()
    {
        if (objectsToHide == null) return;

        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
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
