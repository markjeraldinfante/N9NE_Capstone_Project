using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private CharacterData[] characters = null;
    [SerializeField] private Image player1CharacterSplashHolder = null;
    [SerializeField] private Image player2CharacterSplashHolder = null;
    public PlayerCharacter player1;
    public PlayerCharacter player2;
    private int player1Index;
    private int player2Index;
    private List<CharacterData> unlockedCharacters;
    public is2Player is2Player;

    private void Start()
    {
        unlockedCharacters = new List<CharacterData>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].isUnlocked)
            {
                unlockedCharacters.Add(characters[i]);
            }
        }

        player1Index = 0;
        player2Index = 0;
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
            player1Index--;
            if (player1Index < 0)
            {
                player1Index = unlockedCharacters.Count - 1;
            }
        }
        else if (player == 2)
        {
            player2Index--;
            if (player2Index < 0)
            {
                player2Index = unlockedCharacters.Count - 1;
            }
        }

        UpdateCharacterSplash();
    }

    private void UpdateCharacterSplash()
    {
        if (is2Player.is2P)
        {
            player1CharacterSplashHolder.gameObject.SetActive(true);
            player2CharacterSplashHolder.gameObject.SetActive(true);

            player1CharacterSplashHolder.sprite = unlockedCharacters[player1Index].survivalSplashArt;
            player2CharacterSplashHolder.sprite = unlockedCharacters[player2Index].survivalSplashArt;
            player1.CharacterID = unlockedCharacters[player1Index].id;
            player2.CharacterID = unlockedCharacters[player2Index].id;
        }
        else
        {
            player1CharacterSplashHolder.gameObject.SetActive(true);
            player2CharacterSplashHolder.gameObject.SetActive(false);

            player1CharacterSplashHolder.sprite = unlockedCharacters[player1Index].survivalSplashArt;
            player1.CharacterID = unlockedCharacters[player1Index].id;
        }
    }
}
