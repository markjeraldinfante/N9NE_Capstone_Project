using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerCharacter offlineplayer1Data, offlineplayer2Data;
    public PlayerCharacter onlinePlayerData;
    public CharacterAsset[] characterModels;
    public Transform[] playerSpawnPoints;

    private void Start()
    {

    }

    private void Awake()
    {
        SpawnStartInstantiate.spawn1Player += Spawn1Player;
        SpawnStartInstantiate.spawn2Player += Spawn2Players;
        SpawnStartInstantiate.spawn2PlayerOnline += Spawn1PlayerOnline;
    }

    private void OnDisable()
    {
        SpawnStartInstantiate.spawn1Player -= Spawn1Player;
        SpawnStartInstantiate.spawn2Player -= Spawn2Players;
        SpawnStartInstantiate.spawn2PlayerOnline -= Spawn1PlayerOnline;
    }

    public void Spawn1Player()
    {
        AssignAndInstantiateCharacter(offlineplayer1Data, playerSpawnPoints[0]);
    }

    public void Spawn1PlayerOnline()
    {
        //OnlineAssignAndInstantiateCharacter(onlinePlayerData, player1Transform, player2Transform);
    }

    public void Spawn2Players()
    {
        AssignAndInstantiateCharacter(offlineplayer1Data, playerSpawnPoints[0]);
        AssignAndInstantiateCharacter(offlineplayer2Data, playerSpawnPoints[1]);
    }

    private void AssignAndInstantiateCharacter(PlayerCharacter playerData, Transform playerTransform)
    {
        foreach (var characterModel in characterModels)
        {
            if (characterModel.CharacterID == playerData.CharacterID)
            {
                Instantiate(characterModel.CharacterModel, playerTransform.position, playerTransform.rotation);
                break;
            }
        }
    }

    private void OnlineAssignAndInstantiateCharacter(Transform player1Transform, Transform player2Transform)
    {
        int randomNumber = Random.Range(0, playerSpawnPoints.Length);
        Transform spawnPoint = playerSpawnPoints[randomNumber];
        GameObject playerToSpawn = characterModels[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]].CharacterModel;
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }
}
