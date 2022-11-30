using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New ArcadeGame", menuName = "Aracde/Game")]
public class Arcade : ScriptableObject
{
    public string GameName;
    public Image GameImage;
    public int SceneIndex;


}
