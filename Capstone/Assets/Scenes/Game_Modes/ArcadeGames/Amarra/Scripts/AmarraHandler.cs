using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmarraHandler : MonoBehaviour
{
    private void OnEnable()
    {
        somnium.SoundManager.instance.PlayMusic("AmarraBGM");
    }
}
