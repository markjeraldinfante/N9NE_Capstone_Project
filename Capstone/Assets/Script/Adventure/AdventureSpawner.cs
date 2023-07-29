using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureSpawner : MonoBehaviour
{
    public basePlayerSelect adventureData;
    public CharacterAsset[] characterModels;
    public MapContextHandler context;
    public Transform playerSpawnPoints;
    public bool isForMap;
    public Transform mapParent;

    private void Awake()
    {
        if (playerSpawnPoints == null)
        {
            playerSpawnPoints = context.map.mapSpawn.transform;
        }

        if (mapParent != null)
        {
            Instantiate(context.map.mapEnv, mapParent);
        }

        // Call the Initialized method outside of the if statement
        Initialized();
    }


    public void MapInstantiate()
    {

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
