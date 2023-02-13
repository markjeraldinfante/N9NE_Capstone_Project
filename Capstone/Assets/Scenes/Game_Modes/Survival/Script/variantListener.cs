using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantListener : MonoBehaviour
{
    public baseSurvivalVariant variant;
    public is2Player is2Player;
    public PlayerCharacter player1, player2;
    public GameObject _1playerselection, _2playerselection;

    private void Awake()
    {
        if (variant.mode == baseSurvivalVariant.GameMode.Offline)
        {
            switch (variant.players)
            {
                case baseSurvivalVariant.PlayerCount.Single:
                    is2Player.is2P = false;
                    _1playerselection.SetActive(true);
                    _2playerselection.SetActive(false);
                    break;

                case baseSurvivalVariant.PlayerCount.Multiplayer:
                    is2Player.is2P = true;
                    _1playerselection.SetActive(true);
                    _2playerselection.SetActive(true);
                    break;
            }
        }
    }

}
