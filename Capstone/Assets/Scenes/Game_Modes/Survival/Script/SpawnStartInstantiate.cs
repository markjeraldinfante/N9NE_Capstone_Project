using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartInstantiate : MonoBehaviour
{
    public delegate void Instantiate1Player();
    public delegate void Instantiate2Player();
    public static event Instantiate1Player spawn1Player;
    public static event Instantiate2Player spawn2Player;
    public baseSurvivalVariant variant;

    private void Awake()
    {

        if (variant.players == baseSurvivalVariant.PlayerCount.Multiplayer)
        {
            spawn2Player?.Invoke();
            return;
        }
        else
            spawn1Player?.Invoke();
    }

}
