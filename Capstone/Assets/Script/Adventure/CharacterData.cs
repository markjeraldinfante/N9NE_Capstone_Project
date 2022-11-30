using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character", menuName = "Adventure/Character")]
public class CharacterData : ScriptableObject
{

    public class Arcade : ScriptableObject
    {
        public string CharacterName;
        public Sprite CharacterIcon;
        public GameObject CharacterModel;


    }
}
