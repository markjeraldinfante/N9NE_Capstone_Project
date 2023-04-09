using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingState : MonoBehaviour
{
    public static SavingState instance;
    [Header("Map Data")]
    [SerializeField] private MapSO Upper;
    [SerializeField] private MapSO Lower;
    [SerializeField] private MapSO SaltLake;
    [SerializeField] private MapSO Improve;
    [SerializeField] private MapSO Central;

    [Header("Character Data")]
    [SerializeField] private CharacterData Omar;
    [SerializeField] private CharacterData Junnie;
    [SerializeField] private CharacterData Rico;
    [SerializeField] private CharacterData Azule;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveState()
    {

    }
}
