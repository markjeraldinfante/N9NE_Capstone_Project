using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public baseSurvivalVariant variant;
    public GameObject _1playerselection, _2playerselection, offlineStart, onlineStart;

    private void Awake()
    {
        switch (variant.Mode)
        {
            case baseSurvivalVariant.GameMode.Offline:
                _1playerselection.SetActive(true);
                offlineStart.SetActive(true);
                onlineStart.SetActive(false);
                switch (variant.Players)
                {
                    case baseSurvivalVariant.PlayerCount.Single:
                        _2playerselection.SetActive(false);
                        break;

                    case baseSurvivalVariant.PlayerCount.Multiplayer:
                        _2playerselection.SetActive(true);
                        break;
                }
                break;
            case baseSurvivalVariant.GameMode.Online:
                offlineStart.SetActive(false);
                onlineStart.SetActive(true);
                _1playerselection.SetActive(true);
                _2playerselection.SetActive(false);
                break;
        }

    }

}
