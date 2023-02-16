using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerCharacter : ScriptableObject
{
    [SerializeField] private string PlayerName;
    [SerializeField] private string CharacterID;

    public string playerName { get => PlayerName; set => PlayerName = value; }
    public string charID { get => CharacterID; set => CharacterID = value; }
}
