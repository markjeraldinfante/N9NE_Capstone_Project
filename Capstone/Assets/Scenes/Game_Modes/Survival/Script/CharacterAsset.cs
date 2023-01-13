using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterAsset : ScriptableObject
{
    public string CharacterID;
    public string CharacterName;
    public Sprite CharacterImage;
    public GameObject CharacterModel;
}
