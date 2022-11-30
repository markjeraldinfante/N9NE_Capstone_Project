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
            PlayerPrefs.SetFloat("_SFX", value);
        }
        public void SetBGM(float value)
        {
            BGMSource.volume = value;
            PlayerPrefs.SetFloat("_BGM", value);
        }
        #endregion

    }
}

