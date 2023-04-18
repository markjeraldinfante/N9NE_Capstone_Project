using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerCharacter offlineplayer1Data, offlineplayer2Data;

    public CharacterAsset[] characterModels;
    public Transform[] playerSpawnPoints;

    private void Start()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }


    private void OnEnable()
    {
        SpawnStartInstantiate.spawn1Player += Spawn1Player;
        SpawnStartInstantiate.spawn2Player += Spawn2Players;
        // SpawnStartInstantiate.spawn2PlayerOnline += Spawn1PlayerOnline;
    }

    private void OnDisable()
    {
        SpawnStartInstantiate.spawn1Player -= Spawn1Player;
        SpawnStartInstantiate.spawn2Player -= Spawn2Players;
        PhotonNetwork.RemoveCallbackTarget(this);
        // SpawnStartInstantiate.spawn2PlayerOnline -= Spawn1PlayerOnline;
        Clear();
    }
    void Clear()
    {
        offlineplayer1Data.CharacterID = "";
        offlineplayer1Data.PlayerName = "";
        offlineplayer2Data.CharacterID = "";
        offlineplayer2Data.PlayerName = "";
    }
    public void Spawn1Player()
    {
        if (offlineplayer1Data != null)
        {
            AssignAndInstantiateCharacter(offlineplayer1Data, playerSpawnPoints[0], basePlayer.Player1);
        }
        else
        {
            Debug.LogError("offlineplayer1Data is null!");
        }
    }

    public void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        if (PhotonNetwork.IsConnectedAndReady)
        { OnlineAssignAndInstantiateCharacter(); }

    }
    public void Spawn1PlayerOnline()
    {
        OnlineAssignAndInstantiateCharacter();
    }

    public void Spawn2Players()
    {
        if (offlineplayer1Data != null && offlineplayer2Data != null)
        {
            AssignAndInstantiateCharacter(offlineplayer1Data, playerSpawnPoints[0], basePlayer.Player1);
            AssignAndInstantiateCharacter(offlineplayer2Data, playerSpawnPoints[1], basePlayer.Player2);
        }
        else
        {
            Debug.LogError("offlineplayer1Data or offlineplayer2Data is null!");
        }
    }


    private void AssignAndInstantiateCharacter(PlayerCharacter playerData, Transform playerTransform, basePlayer basePlayer)
    {
        foreach (var characterModel in characterModels)
        {
            if (characterModel.CharacterID == playerData.CharacterID)
            {
                var player = Instantiate(characterModel.CharacterModel, playerTransform.position, playerTransform.rotation);
                var playerMovement = player.GetComponent<PlayerMultiplayer>();
                var survivalAttack = player.GetComponent<Player_Survival_Attack>();
                if (playerMovement != null)
                {
                    playerMovement.basePlayer = basePlayer;
                    survivalAttack.basePlayer = basePlayer;
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
