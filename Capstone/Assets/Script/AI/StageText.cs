using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageText : MonoBehaviour
{
    [SerializeField] private LevelBase[] levels = new LevelBase[5];
    [SerializeField] private GameObject[] levelTexts = new GameObject[5];
    [SerializeField] private GameObject[] levelObjects = new GameObject[5];


    private void Awake()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            LevelBase level = levels[i];
            GameObject levelText = levelTexts[i];
            GameObject levelObject = levelObjects[i];

            if (i == 0) // check if it's the first level
            {
                if (level.isCleared) // check if level 1 is cleared
                {
                    levelObject.SetActive(false); // hide level 1 object
                    levelText.SetActive(false); // hide level 1 text
                    level.lightCleared.SetActive(false); // hide level 1 light
                    level = levels[i + 1]; // set the current level to level 2
                    levelObject = levelObjects[i + 1]; // set the current object to level 2 object
                }

                level.isCleared = true; // set isCleared to true for level 1 or 2
                levelText.SetActive(true);
                levelObject.SetActive(true);
                level.lightCleared.SetActive(true);
            }
            else if (level.isCleared)
            {
                levelText.SetActive(true);
                levelObject.SetActive(true);
                level.lightCleared.SetActive(true);
            }
            else
            {
                levelText.SetActive(false);
                levelObject.SetActive(false);
            }
        }
    }


}
