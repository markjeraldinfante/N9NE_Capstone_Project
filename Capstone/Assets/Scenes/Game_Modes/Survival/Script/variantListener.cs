using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public baseSurvivalVariant variant;
    public PlayerCharacter player1, player2;
    public GameObject _1playerselection, _2playerselection;

    private void Awake()
    {
        if (variant.mode == baseSurvivalVariant.GameMode.Offline)
        {
            switch (variant.players)
            {
                case baseSurvivalVariant.PlayerCount.Single:
                    _1playerselection.SetActive(true);
                    break;

                case baseSurvivalVariant.PlayerCount.Multiplayer:
                    _2playerselection.SetActive(true);
                    break;
            }
        }
    }

}
