using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureSpawner : MonoBehaviour
{
    public basePlayerSelect adventureData;
    public CharacterAsset[] characterModels;
    public Transform playerSpawnPoints;

    private void Awake()
    {
        Initialized();
    }

    private void Initialized()
    {
        foreach (var characterModel in characterModels)
        {
            if (characterModel.CharacterID == adventureData.CharacterID)
            {
                var player = Instantiate(characterModel.CharacterModel, playerSpawnPoints.position, playerSpawnPoints.rotation);
            }
        }
    }

}
