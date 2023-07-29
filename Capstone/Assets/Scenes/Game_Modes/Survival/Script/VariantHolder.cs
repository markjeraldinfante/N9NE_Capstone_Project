using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VariantHolder : MonoBehaviour
{

    public void PlaySinglePlayerOffline()
    {
        SavingState.instance.survivalVariant.variantType = baseSurvivalVariant.VariantType.SinglePlayer;
    }

    public void PlayMultiplayerOffline()
    {
        SavingState.instance.survivalVariant.variantType = baseSurvivalVariant.VariantType.TwoPlayer;
    }

    public void PlayMultiplayerOnline()
    {
        SavingState.instance.survivalVariant.variantType = baseSurvivalVariant.VariantType.Online;
    }


}
