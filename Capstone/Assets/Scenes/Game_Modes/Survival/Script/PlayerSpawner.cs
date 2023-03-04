using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerCharacter offlineplayer1Data, offlineplayer2Data;

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
        AssignAndInstantiateCharacter(offlineplayer1Data, playerSpawnPoints[0], basePlayer.Player1);
    }

    public void Spawn1PlayerOnline()
    {
        OnlineAssignAndInstantiateCharacter();
    }

    public void Spawn2Players()
    {
        AssignAndInstantiateCharacter(offlineplayer1Data, playerSpawnPoints[0], basePlayer.Player1);
        AssignAndInstantiateCharacter(offlineplayer2Data, playerSpawnPoints[1], basePlayer.Player2);
    }

    private void AssignAndInstantiateCharacter(PlayerCharacter playerData, Transform playerTransform, basePlayer basePlayer)
    {
        foreach (var characterModel in characterModels)
        {
            if (characterModel.CharacterID == playerData.CharacterID)
            {
                var player = Instantiate(characterModel.CharacterModel, playerTransform.position, playerTransform.rotation);
                var playerMovement = player.GetComponent<PlayerMultiplayer>();
                var meleeAttack_adventure = player.GetComponent<meleeAttack_adventure>();
                if (playerMovement != null)
                {
                    playerMovement.basePlayer = basePlayer;
                    meleeAttack_adventure.basePlayer = basePlayer;
                }
                break;
            }
        }
    }


    private void OnlineAssignAndInstantiateCharacter()
    {
        int spawnPointIndex = PhotonNetwork.IsMasterClient ? 0 : 1;
        Transform spawnPoint = playerSpawnPoints[spawnPointIndex];
        GameObject playerToSpawn = characterModels[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]].CharacterModel;
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }

}
