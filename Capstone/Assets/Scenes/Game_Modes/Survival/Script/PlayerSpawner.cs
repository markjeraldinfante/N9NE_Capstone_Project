using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerCharacter player1Data, player2Data;
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
        AssignAndInstantiateCharacter(player1Data, player1Transform);
    }
    public void Spawn1PlayerOnline()
    {
        AssignAndInstantiateCharacter(player1Data, player1Transform);
    }

    public void Spawn2Players()
    {
        AssignAndInstantiateCharacter(player1Data, player1Transform);
        AssignAndInstantiateCharacter(player2Data, player2Transform);
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
}
