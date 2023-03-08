using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBHandler : MonoBehaviour
{
    public delegate void OnValueChanged(int newValue);
    public event OnValueChanged newValueTanso;
    public static DBHandler instance;

    public PlayerDB MainPlayerDB;
    public MiniGameManager Amarra;
    public MiniGameManager Litex;

    private PlayerPrefListener listener;


    // to be fix pa
    private void Awake()
    {
        LoadSave();
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

    void LoadSave()
    {
        var gameSystem = new GameSystem();
        // Somnium
        MainPlayerDB.TansoCount = gameSystem.Load(PlayerPrefKeys.TANSO);
        MainPlayerDB.PlayerName = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);

        //Amarra_Minigame
        Amarra.TotalAward = gameSystem.Load(PlayerPrefKeys.TANSO);
        Litex.TotalAward = gameSystem.Load(PlayerPrefKeys.TANSO);
        //temp
        Debug.Log(MainPlayerDB.TansoCount);
        Debug.Log("DATA BASE LOADED");
    }



    private void Start()
    {
        PlayerPrefListener.Instance.StartListening(PlayerPrefKeys.TANSO);
        PlayerPrefListener.Instance.OnValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(int newValue)
    {
        UpdateTanso(newValue);
        Debug.Log("Tanso Updated to: " + newValue);
    }
    public void UpdateTanso(int newValue)
    {

        var gameSystem = new GameSystem();
        gameSystem.Save(newValue, PlayerPrefKeys.TANSO);
        MainPlayerDB.TansoCount = newValue;
        Amarra.TotalAward = newValue;
        Litex.TotalAward = newValue;

        // Raise event for tanso value change
        if (newValueTanso != null)
        {
            newValueTanso(newValue);
        }

        // Debug statement
        Debug.Log("New tanso value: " + newValue);

    }


    public void AddTansoOnCollision()
    {
        MainPlayerDB.TansoCount += 1;
        UpdateTanso(MainPlayerDB.TansoCount);
    }
}
