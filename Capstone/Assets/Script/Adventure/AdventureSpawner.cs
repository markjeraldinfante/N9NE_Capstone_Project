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

    private void Awake()
    {
        if (playerSpawnPoints == null) { playerSpawnPoints = context.map.mapSpawn.transform; }
        Instantiate(context.map.mapEnv);
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
