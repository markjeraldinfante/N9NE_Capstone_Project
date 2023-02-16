using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerCharacter offlineplayer1Data, offlineplayer2Data, onlinePlayerData;
    public CharacterAsset[] characterModels;
    public Transform player1Transform, player2Transform;

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
        AssignAndInstantiateCharacter(offlineplayer1Data, player1Transform);
    }
    public void Spawn1PlayerOnline()
    {
        OnlineAssignAndInstantiateCharacter(onlinePlayerData, player1Transform, player2Transform);
        Debug.Log("check test online");
    }

    public void Spawn2Players()
    {
        AssignAndInstantiateCharacter(offlineplayer1Data, player1Transform);
        AssignAndInstantiateCharacter(offlineplayer2Data, player2Transform);
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
    private void OnlineAssignAndInstantiateCharacter(PlayerCharacter playerData, Transform player1Transform, Transform player2Transform)
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            foreach (var characterModel in characterModels)
            {
                if (characterModel.CharacterID == playerData.CharacterID)
                {

                    if (PhotonNetwork.IsMasterClient)
                    {
                        // Instantiate the character for the host player at player1Transform
                        PhotonNetwork.Instantiate(characterModel.CharacterModel.name, player1Transform.position, player1Transform.rotation);
                    }
                    else
                    {
                        // Instantiate the character for the non-host player at player2Transform
                        PhotonNetwork.Instantiate(characterModel.CharacterModel.name, player2Transform.position, player2Transform.rotation);
                    }
                }
            }

        }
        else Debug.Log("Not connected");
    }
}
