using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private CharacterData[] characters = null;
    [SerializeField] private Image characterSplashHolder = null;
    private int index;
    private List<CharacterData> unlockedCharacters;

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

        index = 0;
        UpdateCharacterSplash();
    }

    public void NextCharacter()
    {
        index = (index + 1) % unlockedCharacters.Count;
        UpdateCharacterSplash();
    }

    public void PreviousCharacter()
    {
        index--;
        if (index < 0)
        {
            index = unlockedCharacters.Count - 1;
        }
        UpdateCharacterSplash();
    }

    private void UpdateCharacterSplash()
    {
        characterSplashHolder.sprite = unlockedCharacters[index].survivalSplashArt;
    }
}
