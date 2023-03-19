using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character", menuName = "Adventure/Character")]
public class CharacterData : ScriptableObject
{
    public string id;
    public string CharacterName;
    public Sprite CharacterIcon;
    public string VoicePicking;
    public string CharacterDetails;
    public Sprite survivalSplashArt;
    public bool isUnlocked;

}
