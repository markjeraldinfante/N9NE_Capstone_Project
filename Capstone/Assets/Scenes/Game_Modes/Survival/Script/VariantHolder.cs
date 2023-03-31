using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VariantHolder : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variantData;

    public void PlaySinglePlayerOffline()
    {
        variantData.variantType = baseSurvivalVariant.VariantType.SinglePlayer;
    }

    public void PlayMultiplayerOffline()
    {
        variantData.variantType = baseSurvivalVariant.VariantType.TwoPlayer;
    }

    public void PlayMultiplayerOnline()
    {
        variantData.variantType = baseSurvivalVariant.VariantType.Online;
    }


}
