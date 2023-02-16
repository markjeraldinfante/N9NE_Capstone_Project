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

    [SerializeField] private GameMode mode;
    [SerializeField] private PlayerCount players;

    public GameMode Mode { get => mode; set => mode = value; }
    public PlayerCount Players { get => players; set => players = value; }
}
