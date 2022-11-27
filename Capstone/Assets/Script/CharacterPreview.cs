using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CharacterPreview : MonoBehaviour
    {
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

  


