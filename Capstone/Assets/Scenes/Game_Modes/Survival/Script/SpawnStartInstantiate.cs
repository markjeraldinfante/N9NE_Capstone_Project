using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartInstantiate : MonoBehaviour
{
    public delegate void Instantiate1Player();
    public delegate void Instantiate2Player();
    public static event Instantiate1Player spawn1Player;
    public static event Instantiate2Player spawn2Player;
    public is2Player is2Player;

    private void Awake()
    {

        if (is2Player.is2P)
        {
            spawn2Player?.Invoke();
            return;
        }
        else
            spawn1Player?.Invoke();
    }

}
