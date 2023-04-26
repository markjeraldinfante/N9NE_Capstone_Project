using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AdventureLoader : MonoBehaviour
{
    [SerializeField] private CharacterData nextCharacter;
    [SerializeField] private MapSO nextMapUnlock;
    [SerializeField] private LandTitleBase landPiece;

    [SerializeField] private LevelBase level;
    public TextMeshProUGUI errMessage;
    [SerializeField] private GameObject loadingScreen = null;
    [SerializeField] private GameObject[] objectsToHide = null;
    [SerializeField]
    EnemyCounter enemyCounter;
    public bool isForLevel5;
    public void LoadLevel(int sceneIndex)
    {
        if (enemyCounter.GetEnemyState())
        {
            if (isForLevel5)
            {
                Unlocks();
            }
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
    private void Unlocks()
    {
        if (nextCharacter != null)
        {
            SavingState.instance.SaveCharacter(nextCharacter, true);
        }
        if (nextMapUnlock != null)
        {
            SavingState.instance.SaveMap(nextMapUnlock, true);
        }
        SavingState.instance.SaveLandPiece(landPiece, true);

        SavingState.instance.SaveState();
    }
}
