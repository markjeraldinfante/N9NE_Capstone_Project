using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject
    player1, player2;
    public Transform
    player1Trans, player2Trans;
    void Awake()
    {
        SpawnStartInstantiate.spawn1Player += Spawn1Player;
        SpawnStartInstantiate.spawn2Player += Spawn2Players;
    }
    private void OnDisable()
    {
        SpawnStartInstantiate.spawn1Player -= Spawn1Player;
        SpawnStartInstantiate.spawn2Player -= Spawn2Players;

    }
    public void Spawn1Player()
    {
        Instantiate(player1, player1Trans.position, player1Trans.rotation);
    }

    public void Spawn2Players()
    {
        Instantiate(player1, player1Trans.position, player1Trans.rotation);
        Instantiate(player2, player2Trans.position, player2Trans.rotation);
    }
}
