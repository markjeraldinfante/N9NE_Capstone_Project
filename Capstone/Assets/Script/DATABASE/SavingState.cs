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
    [SerializeField] private MiniGameData Amarra;
    [SerializeField] private MiniGameData JunkYard;
    [SerializeField] private MiniGameData Litex;
    [SerializeField] private MiniGameData Loco;
    [SerializeField] private MiniGameData BatoPick;

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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SaveState();
            Debug.Log("Saving");
        }
    }
    private void LoadState()
    {
        //Character Data
        Omar.isUnlocked = PlayerPrefs.GetInt("Omar") != 0;
        Junnie.isUnlocked = PlayerPrefs.GetInt("Junnie") != 0;
        Rico.isUnlocked = PlayerPrefs.GetInt("Rico") != 0;
        Azule.isUnlocked = PlayerPrefs.GetInt("Azule") != 0;

        //MiniGame
        Amarra.IsBought = PlayerPrefs.GetInt("AmarraMG") != 0;
        JunkYard.IsBought = PlayerPrefs.GetInt("JunkYardMG") != 0;
        Litex.IsBought = PlayerPrefs.GetInt("LitexMG") != 0;
        Loco.IsBought = PlayerPrefs.GetInt("LocoMG") != 0;
        BatoPick.IsBought = PlayerPrefs.GetInt("BatoPickMG") != 0;

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

        //Stage 1
        stage1Level1.isCleared = PlayerPrefs.GetInt("stage1Level1") != 0;
        stage1Level2.isCleared = PlayerPrefs.GetInt("stage1Level2") != 0;
        stage1Level3.isCleared = PlayerPrefs.GetInt("stage1Level3") != 0;
        stage1Level4.isCleared = PlayerPrefs.GetInt("stage1Level4") != 0;
        stage1Level5.isCleared = PlayerPrefs.GetInt("stage1Level5") != 0;

        //Stage 2
        stage2Level1.isCleared = PlayerPrefs.GetInt("stage2Level1") != 0;
        stage2Level2.isCleared = PlayerPrefs.GetInt("stage2Level2") != 0;
        stage2Level3.isCleared = PlayerPrefs.GetInt("stage2Level3") != 0;
        stage2Level4.isCleared = PlayerPrefs.GetInt("stage2Level4") != 0;
        stage2Level5.isCleared = PlayerPrefs.GetInt("stage2Level5") != 0;

        //Stage 3
        stage3Level1.isCleared = PlayerPrefs.GetInt("stage3Level1") != 0;
        stage3Level2.isCleared = PlayerPrefs.GetInt("stage3Level2") != 0;
        stage3Level3.isCleared = PlayerPrefs.GetInt("stage3Level3") != 0;
        stage3Level4.isCleared = PlayerPrefs.GetInt("stage3Level4") != 0;
        stage3Level5.isCleared = PlayerPrefs.GetInt("stage3Level5") != 0;

        //Stage 4
        stage4Level1.isCleared = PlayerPrefs.GetInt("stage4Level1") != 0;
        stage4Level2.isCleared = PlayerPrefs.GetInt("stage4Level2") != 0;
        stage4Level3.isCleared = PlayerPrefs.GetInt("stage4Level3") != 0;
        stage4Level4.isCleared = PlayerPrefs.GetInt("stage4Level4") != 0;
        stage4Level5.isCleared = PlayerPrefs.GetInt("stage4Level5") != 0;

        //Stage 5
        stage5Level1.isCleared = PlayerPrefs.GetInt("stage5Level1") != 0;
        stage5Level2.isCleared = PlayerPrefs.GetInt("stage5Level2") != 0;
        stage5Level3.isCleared = PlayerPrefs.GetInt("stage5Level3") != 0;
        stage5Level4.isCleared = PlayerPrefs.GetInt("stage5Level4") != 0;
        stage5Level5.isCleared = PlayerPrefs.GetInt("stage5Level5") != 0;
    }
    public void Default()
    {
        Debug.Log("Loading default..");
        Omar.isUnlocked = true;
        Upper.isUnlocked = true;

        PlayerPrefs.SetInt("Omar", (Omar.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Upper", (Upper.isUnlocked ? 1 : 0));
    }


    /// <summary>
    /// Save All Settings
    /// </summary>

    public void SaveState()
    {
        //Character
        PlayerPrefs.SetInt("Omar", (Omar.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Junnie", (Junnie.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Rico", (Rico.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Azule", (Azule.isUnlocked ? 1 : 0));

        //MiniGame
        PlayerPrefs.SetInt("AmarraMG", (Amarra.IsBought ? 1 : 0));
        PlayerPrefs.SetInt("JunkYardMG", (JunkYard.IsBought ? 1 : 0));
        PlayerPrefs.SetInt("LitexMG", (Litex.IsBought ? 1 : 0));
        PlayerPrefs.SetInt("LocoMG", (Loco.IsBought ? 1 : 0));
        PlayerPrefs.SetInt("BatoPickMG", (BatoPick.IsBought ? 1 : 0));

        //Map
        PlayerPrefs.SetInt("Upper", (Upper.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Lower", (Lower.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("SaltLake", (SaltLake.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Improve", (Improve.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Central", (Central.isUnlocked ? 1 : 0));

        //Land Pieces
        PlayerPrefs.SetInt("Piece1", (Piece1.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece2", (Piece2.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece3", (Piece3.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece4", (Piece4.isUnlocked ? 1 : 0));
        PlayerPrefs.SetInt("Piece5", (Piece5.isUnlocked ? 1 : 0));

        //Stage 1
        PlayerPrefs.SetInt("stage1Level1", (stage1Level1.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage1Level2", (stage1Level2.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage1Level3", (stage1Level3.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage1Level4", (stage1Level4.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage1Level5", (stage1Level5.isCleared ? 1 : 0));

        //Stage 2
        PlayerPrefs.SetInt("stage2Level1", (stage2Level1.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage2Level2", (stage2Level2.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage2Level3", (stage2Level3.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage2Level4", (stage2Level4.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage2Level5", (stage2Level5.isCleared ? 1 : 0));

        //Stage 3
        PlayerPrefs.SetInt("stage3Level1", (stage3Level1.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage3Level2", (stage3Level2.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage3Level3", (stage3Level3.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage3Level4", (stage3Level4.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage3Level5", (stage3Level5.isCleared ? 1 : 0));

        //Stage 4
        PlayerPrefs.SetInt("stage4Level1", (stage4Level1.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage4Level2", (stage4Level2.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage4Level3", (stage4Level3.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage4Level4", (stage4Level4.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage4Level5", (stage4Level5.isCleared ? 1 : 0));

        //Stage 5
        PlayerPrefs.SetInt("stage5Level1", (stage5Level1.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage5Level2", (stage5Level2.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage5Level3", (stage5Level3.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage5Level4", (stage5Level4.isCleared ? 1 : 0));
        PlayerPrefs.SetInt("stage5Level5", (stage5Level5.isCleared ? 1 : 0));


        Debug.Log("Saving state..");
    }
    /// <summary>
    /// Save Land Title Piece 
    /// </summary>
    /// <param name="landTitleSO"></param>
    /// <param name="isUnlocked"></param>
    public void SaveLandPiece(LandTitleBase landTitleSO, bool isUnlocked)
    {
        landTitleSO.isUnlocked = isUnlocked;
    }

    /// <summary>
    /// Save Character 
    /// </summary>
    /// <param name="characterDataSO"></param>
    /// <param name="isUnlocked"></param>
    public void SaveCharacter(CharacterData characterDataSO, bool isUnlocked)
    {
        characterDataSO.isUnlocked = isUnlocked;
    }

    /// <summary>
    /// Save Map
    /// </summary>
    /// <param name="mapSO"></param>
    /// <param name="isUnlocked"></param>
    public void SaveMap(MapSO mapSO, bool isUnlocked)
    {
        mapSO.isUnlocked = isUnlocked;
    }

    /// <summary>
    /// Save Stage Level
    /// </summary>
    /// <param name="levelBaseSO"></param>
    /// <param name="isCleared"></param>
    public void SaveStageLevel(LevelBase levelBaseSO, bool isCleared)
    {
        levelBaseSO.isCleared = isCleared;
    }

    /// <summary>
    /// Save Minigame 
    /// </summary>
    /// <param name="miniGame"></param>
    /// <param name="isBought"></param>
    public void SaveMiniGame(MiniGameData miniGame, bool isBought)
    {
        miniGame.IsBought = isBought;
    }
}
