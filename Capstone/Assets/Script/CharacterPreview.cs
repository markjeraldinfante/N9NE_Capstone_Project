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

    private void Awake()
    {
        selectedCharacter.CharacterID = PlayerPrefs.GetString(PlayerPrefKeys.SELECTED_CHARACTER, "0");
    }

    public void DisplayAvatar(string id)
    {
        for (int i = 0; i < CharacterModel.Count; i++)
        {
            if (CharacterModel[i].getID() == id)
            {
                CharacterModel[i].gameObject.SetActive(true);
                selectedCharacter.CharacterID = id;
                PlayerPrefs.SetString(selectedCharacter.CharacterID, PlayerPrefKeys.SELECTED_CHARACTER);
            }

            else
                CharacterModel[i].gameObject.SetActive(false);

        }

    }

}




