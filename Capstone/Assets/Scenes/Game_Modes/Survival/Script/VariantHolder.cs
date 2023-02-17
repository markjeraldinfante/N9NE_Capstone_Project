using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantHolder : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variantData;
    public void PlaySinglePlayerOffline()
    {
        variantData.isOnline = false;
        variantData.players = baseSurvivalVariant.PlayerCount.Single;
    }

    public void PlayMultiplayerOffline()
    {
        variantData.isOnline = false;
        variantData.players = baseSurvivalVariant.PlayerCount.Multiplayer;
    }
    public void PlayMultiplayerOnline()
    {
        variantData.isOnline = true;
    }

}
