using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private string BGM_Name;
    void OnEnable()
    {
        somnium.SoundManager.instance.onPlayMusic();
        somnium.SoundManager.instance.PlayMusic(BGM_Name);
    }
    private void OnDisable()
    {
        somnium.SoundManager.instance.StopMusic();
    }


}
