using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public GameObject _1playerselection, _2playerselection;

    private void Start()
    {
        if (SavingState.instance.survivalVariant.variantType == baseSurvivalVariant.VariantType.SinglePlayer)
        {
            _1playerselection.SetActive(true);
        }
        if (SavingState.instance.survivalVariant.variantType == baseSurvivalVariant.VariantType.TwoPlayer)
        {
            _1playerselection.SetActive(true);
            _2playerselection.SetActive(true);
        }
    }
}


