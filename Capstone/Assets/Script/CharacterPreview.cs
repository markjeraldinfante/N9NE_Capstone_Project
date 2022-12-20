using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterPreview : MonoBehaviour
{
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charDetails;
    public List<CharData> CharacterModel;

    public void DisplayAvatar(string id)
    {
        for (int i = 0; i < CharacterModel.Count; i++)
        {
            if (CharacterModel[i].getID() == id)
                CharacterModel[i].gameObject.SetActive(true);
            else
                CharacterModel[i].gameObject.SetActive(false);

        }

    }

}




