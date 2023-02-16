using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public baseSurvivalVariant variant;
    public GameObject _1playerselection, _2playerselection;

    private void Awake()
    {
        if (variant.mode == baseSurvivalVariant.GameMode.Offline)
        {
            switch (variant.players)
            {
                case baseSurvivalVariant.PlayerCount.Single:
                    _1playerselection.SetActive(true);
                    _2playerselection.SetActive(false);
                    break;

                case baseSurvivalVariant.PlayerCount.Multiplayer:
                    _1playerselection.SetActive(true);
                    _2playerselection.SetActive(true);
                    break;
            }
        }
        if (variant.mode == baseSurvivalVariant.GameMode.Online)
        {
            switch (variant.players)
            {
                case baseSurvivalVariant.PlayerCount.Multiplayer:
                    _1playerselection.SetActive(true);
                    _2playerselection.SetActive(false);
                    break;
            }
        }
    }

}
