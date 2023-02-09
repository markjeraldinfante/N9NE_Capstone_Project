using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterPreview : MonoBehaviour
{
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charDetails;
    public List<CharData> CharacterModel;
    public basePlayerSelect selectedCharacter;
    private void Start()
    {
        LoadCharacter.showChar += ShowCharacter;
    }
    private void OnDisable()
    {
        LoadCharacter.showChar -= ShowCharacter;
    }

    public void ShowCharacter()
    {
        string ID = PlayerPrefs.GetString(PlayerPrefKeys.SELECTED_CHARACTER, "1");
        string Name = PlayerPrefs.GetString(PlayerPrefKeys.SELECTED_CHARACTER_NAME, "Omar");
        string Details = PlayerPrefs.GetString(PlayerPrefKeys.SELECTED_CHARACTER_DETAILS, "Omar was a son of a guard in Barrio Makatipo. When the fighting happens, his father was killed by the men of Netta. Due to his desire for revenge, he plans to fight hard against Netta and his militia for the sake of his father’s death to not be in vain.");
        DisplayAvatar(ID, Name, Details);
    }
    public void DisplayAvatar(string id, string name, string details)
    {
        for (int i = 0; i < CharacterModel.Count; i++)
        {
            if (CharacterModel[i].getID() == id)
            {
                CharacterModel[i].gameObject.SetActive(true);
                SaveSTATE(id, name, details);
            }

            else
                CharacterModel[i].gameObject.SetActive(false);

        }

    }
    public void SaveSTATE(string id, string name, string details)
    {
        selectedCharacter.CharacterID = id;
        charName.text = name;
        charDetails.text = details;

        PlayerPrefs.SetString(PlayerPrefKeys.SELECTED_CHARACTER, selectedCharacter.CharacterID);
        PlayerPrefs.SetString(PlayerPrefKeys.SELECTED_CHARACTER_NAME, charName.text);
        PlayerPrefs.SetString(PlayerPrefKeys.SELECTED_CHARACTER_DETAILS, charDetails.text);
    }
}




