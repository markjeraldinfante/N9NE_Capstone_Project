using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AdventureLoader : MonoBehaviour
{
    [SerializeField] private LevelBase level;
    public TextMeshProUGUI errMessage;
    [SerializeField] private GameObject loadingScreen = null;
    [SerializeField] private GameObject[] objectsToHide = null;
    [SerializeField]
    EnemyCounter enemyCounter;
    public void LoadLevel(int sceneIndex)
    {
        if (enemyCounter.GetEnemyState())
        {
            SaveLevel();
            HideObjects();
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        else
        {
            errMessage.color = Color.red;
            errMessage.text = "Kill all enemies to proceed!";
            StartCoroutine(ClearText(3f));
        }
    }

    IEnumerator ClearText(float delay)
    {
        yield return new WaitForSeconds(delay);
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
    private void SaveLevel()
    {
        SavingState.instance.SaveStageLevel(level, true);
        SavingState.instance.SaveState();
    }
}
