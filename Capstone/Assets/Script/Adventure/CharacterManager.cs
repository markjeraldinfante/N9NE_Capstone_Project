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
    public CharSlot charSlot;
    
    private void Start()
    {
        
        ListCharacters();
       
    }
    public void ListCharacters()
    {
         foreach (var item in charList)
         {
            charSlot._id = item.id;
            GameObject gameObject = Instantiate(characterItem, characterselectionContent);


            var characterName = gameObject.transform.Find("charName").GetComponent<TextMeshProUGUI>();
            var characterID = gameObject.transform.Find("charID").GetComponent<TextMeshProUGUI>();
            var characterIcon = gameObject.transform.Find("charIco").GetComponent<Image>();

            characterName.text = item.CharacterName;
            characterIcon.sprite = item.CharacterIcon;
            characterID.text = item.id;
        
        }

        
       
    }
}
