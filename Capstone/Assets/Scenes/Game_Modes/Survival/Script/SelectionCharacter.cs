using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private CharacterData[] characters = null;
    [SerializeField] private Image player1CharacterSplashHolder = null;
    [SerializeField] private Image player2CharacterSplashHolder = null;
    [SerializeField] private PlayerCharacter onlinePlayer = null;
    [SerializeField] private PlayerCharacter player1 = null;
    [SerializeField] private PlayerCharacter player2 = null;
    [SerializeField] private baseSurvivalVariant variant;

    private int player1Index = 0;
    private int player2Index = 0;
    private List<CharacterData> unlockedCharacters = new List<CharacterData>();

    private void Start()
    {
        unlockedCharacters.AddRange(Array.FindAll(characters, c => c.isUnlocked));
        UpdateCharacterSplash();
    }

    public void NextCharacter(int player)
    {
        if (player == 1)
        {
            player1Index = (player1Index + 1) % unlockedCharacters.Count;
        }
        else if (player == 2)
        {
            player2Index = (player2Index + 1) % unlockedCharacters.Count;
        }

        UpdateCharacterSplash();
    }

    public void PreviousCharacter(int player)
    {
        if (player == 1)
        {
            player1Index = (player1Index + unlockedCharacters.Count - 1) % unlockedCharacters.Count;
        }
        else if (player == 2)
        {
            player2Index = (player2Index + unlockedCharacters.Count - 1) % unlockedCharacters.Count;
        }

        UpdateCharacterSplash();
    }

    private void UpdateCharacterSplash()
    {
        switch (variant.Mode)
        {
            case baseSurvivalVariant.GameMode.Offline:
                switch (variant.Players)
                {
                    case baseSurvivalVariant.PlayerCount.Single:
                        player1CharacterSplashHolder.gameObject.SetActive(true);
                        player1CharacterSplashHolder.sprite = unlockedCharacters[player1Index].survivalSplashArt;
                        player1.charID = unlockedCharacters[player1Index].id;
                        break;
                    case baseSurvivalVariant.PlayerCount.Multiplayer:
                        player1CharacterSplashHolder.gameObject.SetActive(true);
                        player1CharacterSplashHolder.sprite = unlockedCharacters[player1Index].survivalSplashArt;
                        player1.charID = unlockedCharacters[player1Index].id;
                        player2CharacterSplashHolder.gameObject.SetActive(true);
                        player2CharacterSplashHolder.sprite = unlockedCharacters[player2Index].survivalSplashArt;
                        player2.charID = unlockedCharacters[player2Index].id;
                        break;
                }
                break;

            case baseSurvivalVariant.GameMode.Online:
                player1CharacterSplashHolder.gameObject.SetActive(true);
                player1CharacterSplashHolder.sprite = unlockedCharacters[player1Index].survivalSplashArt;
                onlinePlayer.charID = unlockedCharacters[player1Index].id;
                break;

        }
    }
}
