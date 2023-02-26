using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelBase : ScriptableObject
{
    public bool isCleared;
    public int LevelIndex;
    public string[] dialogueLines;
    public GameObject lightCleared;

}

