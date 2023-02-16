using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantHolder : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variantData;
    public void PlaySinglePlayerOffline()
    {
        variantData.Mode = baseSurvivalVariant.GameMode.Offline;
        variantData.Players = baseSurvivalVariant.PlayerCount.Single;
    }

    public void PlayMultiplayerOffline()
    {
        variantData.Mode = baseSurvivalVariant.GameMode.Offline;
        variantData.Players = baseSurvivalVariant.PlayerCount.Multiplayer;
    }
    public void PlayMultiplayerOnline()
    {
        variantData.Mode = baseSurvivalVariant.GameMode.Online;
    }

}
