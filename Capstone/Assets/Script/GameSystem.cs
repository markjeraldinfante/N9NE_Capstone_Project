using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem
{
    public void Save(int score, string playerprefkeys)
    {
        PlayerPrefs.SetInt(playerprefkeys, score);
        PlayerPrefs.Save();
    }

    public int Load(string playerprefkeys)
    {
        return PlayerPrefs.GetInt(playerprefkeys, 0);
    }
}
