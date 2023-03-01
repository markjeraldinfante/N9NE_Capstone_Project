using System.Collections.Generic;
using UnityEngine;

public class StageText : MonoBehaviour
{
    [SerializeField] private List<LevelBase> levels;
    [SerializeField] private List<GameObject> levelObjects;

    private void Awake()
    {
        levelObjects[0].SetActive(true);

        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].isCleared)
            {
                levelObjects[i + 1].SetActive(true);
                levels[i].lightCleared.SetActive(true);
            }
        }
    }
}
