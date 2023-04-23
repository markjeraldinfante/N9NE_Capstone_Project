using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingState : MonoBehaviour
{
    public static SavingState instance;
    [Header("Adventure")]
    public basePlayerSelect playerSelect;

    [Header("Survival")]
    public baseSurvivalVariant survivalVariant;

    [Header("Minigame")]
    public baseMinigame miniGame;

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

    [Header("Land Piece")]
    [SerializeField] private LandTitleBase Piece1;
    [SerializeField] private LandTitleBase Piece2;
    [SerializeField] private LandTitleBase Piece3;
    [SerializeField] private LandTitleBase Piece4;
    [SerializeField] private LandTitleBase Piece5;

    [Header("Stage 1")]
    [SerializeField] private LevelBase stage1Level1;
    [SerializeField] private LevelBase stage1Level2;
    [SerializeField] private LevelBase stage1Level3;
    [SerializeField] private LevelBase stage1Level4;
    [SerializeField] private LevelBase stage1Level5;

    [Header("Stage 2")]
    [SerializeField] private LevelBase stage2Level1;
    [SerializeField] private LevelBase stage2Level2;
    [SerializeField] private LevelBase stage2Level3;
    [SerializeField] private LevelBase stage2Level4;
    [SerializeField] private LevelBase stage2Level5;

    [Header("Stage 3")]
    [SerializeField] private LevelBase stage3Level1;
    [SerializeField] private LevelBase stage3Level2;
    [SerializeField] private LevelBase stage3Level3;
    [SerializeField] private LevelBase stage3Level4;
    [SerializeField] private LevelBase stage3Level5;

    [Header("Stage 4")]
    [SerializeField] private LevelBase stage4Level1;
    [SerializeField] private LevelBase stage4Level2;
    [SerializeField] private LevelBase stage4Level3;
    [SerializeField] private LevelBase stage4Level4;
    [SerializeField] private LevelBase stage4Level5;

    [Header("Stage 5")]
    [SerializeField] private LevelBase stage5Level1;
    [SerializeField] private LevelBase stage5Level2;
    [SerializeField] private LevelBase stage5Level3;
    [SerializeField] private LevelBase stage5Level4;
    [SerializeField] private LevelBase stage5Level5;


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



        LoadState();

    }
    private void Start()
    {
        Default();
        SaveState();
    }
    private void LoadState()
    {
        //Character Data
        Omar.isUnlocked = PlayerPrefs.GetInt("Omar") != 0;
        Junnie.isUnlocked = PlayerPrefs.GetInt("Junnie") != 0;
        Rico.isUnlocked = PlayerPrefs.GetInt("Rico") != 0;
        Azule.isUnlocked = PlayerPrefs.GetInt("Azule") != 0;

        //Map 
        Upper.isUnlocked = PlayerPrefs.GetInt("Upper") != 0;
        Lower.isUnlocked = PlayerPrefs.GetInt("Lower") != 0;
        SaltLake.isUnlocked = PlayerPrefs.GetInt("SaltLake") != 0;
        Improve.isUnlocked = PlayerPrefs.GetInt("Improve") != 0;
        Central.isUnlocked = PlayerPrefs.GetInt("Central") != 0;

        //Land Pieces
        Piece1.isUnlocked = PlayerPrefs.GetInt("Piece1") != 0;
        Piece2.isUnlocked = PlayerPrefs.GetInt("Piece2") != 0;
        Piece3.isUnlocked = PlayerPrefs.GetInt("Piece3") != 0;
        Piece4.isUnlocked = PlayerPrefs.GetInt("Piece4") != 0;
        Piece5.isUnlocked = PlayerPrefs.GetInt("Piece5") != 0;
    }
    public void Default()
    {
        Debug.Log("Loading default..");
        Omar.isUnlocked = true;
        Upper.isUnlocked = true;
    }
    public void SaveState()
    {
        //Character
        PlayerPrefs.SetInt("Omar", (Omar.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Junnie", (Junnie.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Rico", (Rico.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Azule", (Azule.isUnlocked ? 1 : 0));


        //Land Pieces
        PlayerPrefs.SetInt("Piece1", (Piece1.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece2", (Piece2.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece3", (Piece3.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece4", (Piece4.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece5", (Piece5.isUnlocked ? 1 : 0));

        Debug.Log("Saving state..");
    }

    public void SaveLandPiece(LandTitleBase landTitleSO, bool isUnlocked)
    {
        landTitleSO.isUnlocked = isUnlocked;
    }
    public void SaveCharacter(CharacterData characterDataSO, bool isUnlocked)
    {
        characterDataSO.isUnlocked = isUnlocked;
    }
    public void SaveMap(MapSO mapSO, bool isUnlocked)
    {
        mapSO.isUnlocked = isUnlocked;
    }

    public void SaveStageLevel(LevelBase levelBaseSO, bool isCleared)
    {
        levelBaseSO.isCleared = isCleared;
    }
}
