using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class baseSurvivalVariant : ScriptableObject
{

    public enum PlayerCount
    {
        Single,
        Multiplayer
    }


    public PlayerCount players;
    public bool isOnline;

}
