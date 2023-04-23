using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AdventureLoader : MonoBehaviour
{
    public TextMeshProUGUI errMessage;
    [SerializeField] private GameObject loadingScreen = null;
    [SerializeField] private GameObject[] objectsToHide = null;
    [SerializeField]
    EnemyCounter enemyCounter;
    public void LoadLevel(int sceneIndex)
    {
        if (enemyCounter.GetEnemyState())
        {
            HideObjects();
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        else
        {
            errMessage.color = Color.red;
            errMessage.text = "Kill all enemies to proceed !! ";
            StartCoroutine(clearText());
        }
    }
    IEnumerator clearText()
    {
        yield return new WaitForSeconds(1f);
        errMessage.text = "";
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
}
