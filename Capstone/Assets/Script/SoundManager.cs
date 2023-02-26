using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Linq;

namespace somnium
{
    public class SoundManager : MonoBehaviour
    {


        public static SoundManager instance;
        public AudioSource SFXSource, BGMSource;
        public Sounds[] BG_music;
        public Sounds[] sounds_FX;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            float sfxVolume = PlayerPrefs.GetFloat(PlayerPrefKeys.SET_SFX, 0.5f);
            float bgmVolume = PlayerPrefs.GetFloat(PlayerPrefKeys.SET_BGM, 0.5f);

            SFXSource.volume = sfxVolume;
            BGMSource.volume = bgmVolume;

            Debug.Log("SFX volume: " + sfxVolume);
            Debug.Log("BGM volume: " + bgmVolume);
        }


        public void PlayMusic(string name)
        {
            Sounds sound = BG_music.FirstOrDefault(x => x.name == name);

            if (sound == null)
            {
                Debug.Log("Music not found: " + name);
            }
            else
            {
                BGMSource.clip = sound.audioClip;
                BGMSource.Play();
            }
        }

        public void PlaySFX(string name)
        {
            Sounds sound = sounds_FX.FirstOrDefault(x => x.name == name);

            if (sound == null)
            {
                Debug.Log("SFX not found: " + name);
            }
            else
            {
                SFXSource.PlayOneShot(sound.audioClip);
            }
        }

        public void SetSFX(float value)
        {
            SFXSource.volume = value;
            PlayerPrefs.SetFloat(PlayerPrefKeys.SET_SFX, value);
        }

        public void SetBGM(float value)
        {
            BGMSource.volume = value;
            PlayerPrefs.SetFloat(PlayerPrefKeys.SET_BGM, value);
        }
    }
}

