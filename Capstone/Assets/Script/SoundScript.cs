using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace somnium
{ 
    public class SoundScript : MonoBehaviour
    {
        public Slider musicSlider, SFXSlider;
        void Update()
        {
            //AudioSource.volume = musicVolume;
           // soundManager.SetBGM = soundManager.musicVolume;
        }
        public void SetBGM() => SoundManager.instance.SetBGM(musicSlider.value);
        public void SetSFX() => SoundManager.instance.SetSFX(SFXSlider.value);

    

    }
}
