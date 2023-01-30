using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class baseSurvivalVariant : ScriptableObject
{
    public enum GameMode
    {
        Offline,
        Online
    }

    public enum PlayerCount
    {
        Single,
        Multiplayer
    }

    public GameMode mode;
    public PlayerCount players;
}
