using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantHolder : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variantData;
    public void PlaySinglePlayerOffline()
    {
        variantData.mode = baseSurvivalVariant.GameMode.Offline;
        variantData.players = baseSurvivalVariant.PlayerCount.Single;
    }

    public void PlayMultiplayerOffline()
    {
        variantData.mode = baseSurvivalVariant.GameMode.Offline;
        variantData.players = baseSurvivalVariant.PlayerCount.Multiplayer;
    }
    public void PlayMultiplayerOnline()
    {
        variantData.mode = baseSurvivalVariant.GameMode.Online;
        variantData.players = baseSurvivalVariant.PlayerCount.Multiplayer;
    }

}
