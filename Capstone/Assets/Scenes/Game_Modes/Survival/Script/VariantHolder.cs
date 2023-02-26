using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VariantHolder : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variantData;

    public void PlaySinglePlayerOffline()
    {
        SetVariantData(false, false);
    }

    public void PlayMultiplayerOffline()
    {
        SetVariantData(false, true);
    }

    public void PlayMultiplayerOnline()
    {
        SetVariantData(true, false);
    }

    private void SetVariantData(bool isOnline, bool is2player)
    {
        variantData.isOnline = isOnline;
        variantData.is2player = is2player;
    }
}
