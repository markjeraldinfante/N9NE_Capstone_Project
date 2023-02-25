using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureSpawner : MonoBehaviour
{
    public basePlayerSelect adventureData;
    public CharacterAsset[] characterModels;
    public Transform playerSpawnPoints;
    public bool isForMap;

    private void Awake()
    {
        Initialized();
    }

    public void Initialized()
    {
        foreach (var characterModel in characterModels)
        {
            if (characterModel.CharacterID == adventureData.CharacterID)
            {
                if (isForMap)
                {
                    var player = Instantiate(characterModel.modelForMap, playerSpawnPoints.position, playerSpawnPoints.rotation);
                }
                else
                {
                    var player = Instantiate(characterModel.CharacterModel, playerSpawnPoints.position, playerSpawnPoints.rotation);
                }
            }

        }
    }

}
