using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerCharacter offlineplayer1Data, offlineplayer2Data;
    public PlayerCharacter onlinePlayerData;
    public CharacterAsset[] characterModels;
    public Transform player1Transform, player2Transform;
    public PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
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
        AssignAndInstantiateCharacter(offlineplayer1Data, player1Transform);
    }

    public void Spawn1PlayerOnline()
    {
        OnlineAssignAndInstantiateCharacter(onlinePlayerData, player1Transform, player2Transform);
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
        foreach (var characterModel in characterModels)
        {
            if (characterModel.CharacterID == playerData.CharacterID)
            {
                if (photonView.IsMine)
                {
                    Vector3 spawnPos = Vector3.Lerp(player1Transform.position, player2Transform.position, Random.Range(0f, 1f));
                    PhotonNetwork.Instantiate(characterModel.CharacterModel.name, spawnPos, Quaternion.identity, 0);
                }

            }
        }
    }
}
