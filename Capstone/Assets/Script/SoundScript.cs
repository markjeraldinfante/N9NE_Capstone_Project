using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace somnium
{ 
    public class SoundScript : MonoBehaviour
    {

        void Update()
        {
            //AudioSource.volume = musicVolume;
           // soundManager.SetBGM = soundManager.musicVolume;
        }
        public void SetBGM(float volume) => SoundManager.instance.SetBGM(volume);
        public void SetSFX(float volume) => SoundManager.instance.SetSFX(volume);
        
    }
}
