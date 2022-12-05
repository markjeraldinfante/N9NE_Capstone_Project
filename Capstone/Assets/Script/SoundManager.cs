using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace somnium
{
    public class SoundManager : MonoBehaviour
    {

        public static SoundManager instance;
        [SerializeField] AudioSource SFXSource, BGMSource;
        [SerializeField] Sounds[] BG_music;
        [SerializeField] Sounds[] sounds_FX;
   


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);
        }

        private void Start()
        {
                if (!PlayerPrefs.HasKey("SetBGM") && !PlayerPrefs.HasKey("SetSFX"))
                {
                     SFXSource.volume = 0.8f;
                     BGMSource.volume = 0.8f;
             
               
                }
                else
                {
                     SFXSource.volume = PlayerPrefs.GetFloat("SetSFX");
                     BGMSource.volume = PlayerPrefs.GetFloat("SetBGM");
                }


            Debug.Log("SFX VALUE = " + SFXSource.volume);
            Debug.Log("BGM VALUE = " + BGMSource.volume);

        }
        #region AudioController


        public void PlayMusic(string name)
        {
            Sounds sounds = Array.Find(BG_music, x => x.name == name);

            if (sounds == null)
            {
                Debug.Log("Music Not Found!");
            }
            else
            {
                BGMSource.clip = sounds.audioClip;
                BGMSource.Play();
            }

        }
        public void PlaySFX(string name)
        {
            Sounds sounds = Array.Find(sounds_FX, x => x.name == name);

            if (sounds == null)
            {
                Debug.Log("SFX Not Found!");
            }
            else
            {
                SFXSource.PlayOneShot(sounds.audioClip);

            }
        }

        public void SetSFX(float value)
        {
            SFXSource.volume = value;
            //PlayerPrefs.SetFloat("SetSFX", value);
        }
        public void SetBGM(float value)
        {
            BGMSource.volume = value;
            //PlayerPrefs.SetFloat("SetBGM", value);
        }
        #endregion

    }
}

