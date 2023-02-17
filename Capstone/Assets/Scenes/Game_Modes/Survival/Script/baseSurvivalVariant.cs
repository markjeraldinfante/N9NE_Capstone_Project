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

    [SerializeField] public GameMode mode;
    [SerializeField] public PlayerCount players;

}
