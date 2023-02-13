using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace somnium
{
    public class SoundScript : MonoBehaviour
    {
        public Slider musicSlider, SFXSlider;
        private void Awake()
        {
            LoadSettings();
        }

        public void SetBGM()
        {
            SoundManager.instance.SetBGM(musicSlider.value);
            SaveSetting(PlayerPrefKeys.SET_BGM, musicSlider.value);
        }

        public void SetSFX()
        {
            SoundManager.instance.SetSFX(SFXSlider.value);
            SaveSetting(PlayerPrefKeys.SET_SFX, SFXSlider.value);
        }

        private void LoadSettings()
        {
            SoundManager.instance.SetBGM(PlayerPrefs.GetFloat(PlayerPrefKeys.SET_BGM, 0.5f));
            SoundManager.instance.SetSFX(PlayerPrefs.GetFloat(PlayerPrefKeys.SET_SFX, 0.5f));
            musicSlider.value = PlayerPrefs.GetFloat(PlayerPrefKeys.SET_BGM, 0.5f);
            SFXSlider.value = PlayerPrefs.GetFloat(PlayerPrefKeys.SET_SFX, 0.5f);
        }

        private void SaveSetting(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }
    }

}

