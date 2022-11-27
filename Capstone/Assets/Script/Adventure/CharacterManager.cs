using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{

    public List<CharacterData> charList = new List<CharacterData>();

    public Transform characterselectionContent;
    public GameObject characterItem;
    
    public void ListCharacters()
    {
        foreach (var characterdata in charList)
        {
            GameObject gameObject = Instantiate(characterItem, characterselectionContent);
            var characterName = gameObject.transform.Find("CharacterData/CharacterName").GetComponent<TextMeshPro>();
            var characterIcon = gameObject.transform.Find("CharacterData/CharacterIcon").GetComponent<Image>();

            characterdata.CharacterName = characterName.text;
            characterdata.CharacterIcon = characterIcon.sprite;
        }
    }
}
