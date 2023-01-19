using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBHandler : MonoBehaviour
{
    public static DBHandler instance;

    public PlayerDB MainPlayerDB;
    public AmarraManager1 Amarra;


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
        Amarra.TotalAward = PlayerPrefs.GetInt("AMARRA_TOTAL_TANSO");
        MainPlayerDB.PlayerName = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);

        //temp

        MainPlayerDB.TansoCount = Amarra.TotalAward;
        Debug.Log(MainPlayerDB.TansoCount);
        Debug.Log("DATA BASE LOADED");
    }
}
