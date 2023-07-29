using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageText : MonoBehaviour
{
    [SerializeField] private List<LevelBase> levels;
    [SerializeField] private List<GameObject> levelObjects;
    [SerializeField] private List<GameObject> lightCleared;

    private void Awake()
    {
        levelObjects[0].SetActive(true);

        int levelIndex = 1;
        int clearedCount = levels.Count(l => l.isCleared);
        foreach (var level in levels)
        {
            if (levelIndex < levelObjects.Count && level.isCleared)
            {
                levelObjects[levelIndex].SetActive(true);
                Debug.Log("Activated game object for level " + levelIndex + ": " + levelObjects[levelIndex].name);
            }
            if (levelIndex <= clearedCount)
            {
                lightCleared[levelIndex - 1].SetActive(true);
                Debug.Log("Activated light for level " + levelIndex + ": " + lightCleared[levelIndex - 1].name);
            }
            levelIndex++;
        }
    }
}
