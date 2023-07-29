using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnlockCharacter : MonoBehaviour
{
    [SerializeField] private CharacterData[] charData;
    [SerializeField] private GameObject[] charModel;
    void Start()
    {
        for (int i = 0; i < charData.Length; i++)
        {
            if (charData[i].isUnlocked)
            {
                charModel[i].SetActive(true);
            }
            else charModel[i].SetActive(false);
        }
    }
}
