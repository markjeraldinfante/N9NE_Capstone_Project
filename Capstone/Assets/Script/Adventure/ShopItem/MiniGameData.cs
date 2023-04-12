using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Minigame", menuName = "Minigames/Minigame")]
public class MiniGameData : ScriptableObject
{
    public string miniGameName;
    public Sprite miniGameImage;
    public string miniGameDescription;
    public float miniGameCost;
    public bool isBought;

    public float GetMinigameCost()
    {
        return miniGameCost;
    }

}
