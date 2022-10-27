using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace somnium
{ 
    public class SoundScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public somnium.SoundManager soundManager;
        

       
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //AudioSource.volume = musicVolume;
           // soundManager.SetBGM = soundManager.musicVolume;
        }
        public void updateVolume(float volume)
        {
           soundManager.musicVolume  = volume;
        }
    }
}
