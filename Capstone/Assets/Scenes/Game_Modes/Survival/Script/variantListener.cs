using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public baseSurvivalVariant variant;
    public GameObject _1playerselection, _2playerselection;

    private void Awake()
    {
        _1playerselection.SetActive(true);

        if (!variant.isOnline)
        {
            if (!variant.is2player)
            {
                _2playerselection.SetActive(false);
            }
            else
                _2playerselection.SetActive(true);
        }
    }
}


