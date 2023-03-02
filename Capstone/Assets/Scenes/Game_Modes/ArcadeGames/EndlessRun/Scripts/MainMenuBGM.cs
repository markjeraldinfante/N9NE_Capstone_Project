using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        somnium.SoundManager.instance.PlayMusic("LitexMainMenuBG");
    }

  
}
