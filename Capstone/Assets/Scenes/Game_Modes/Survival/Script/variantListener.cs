using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public baseSurvivalVariant variant;
    public GameObject _1playerselection, _2playerselection, offlineStart, onlineStart;

    private void Awake()
    {
        switch (variant.isOnline)
        {
            case false:
                _1playerselection.SetActive(true);
                offlineStart.SetActive(true);
                onlineStart.SetActive(false);
                switch (variant.players)
                {
                    case baseSurvivalVariant.PlayerCount.Single:
                        _2playerselection.SetActive(false);
                        break;

                    case baseSurvivalVariant.PlayerCount.Multiplayer:
                        _2playerselection.SetActive(true);
                        break;
                }
                break;
            case true:
                offlineStart.SetActive(false);
                onlineStart.SetActive(true);
                _1playerselection.SetActive(true);
                _2playerselection.SetActive(false);
                break;
        }

    }

}
