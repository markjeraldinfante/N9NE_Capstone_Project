using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace somnium
{
    public class SoundScript : MonoBehaviour
    {
        [SerializeField] private defaultSetting setting;
        public Slider musicSlider, SFXSlider;
        private void Awake()
        {
            LoadSettings();
        }

        public void SetBGM()
        {
            SoundManager.instance.SetBGM(musicSlider.value);
            setting.BGM = musicSlider.value;
            SaveSetting(PlayerPrefKeys.SET_BGM, musicSlider.value);
        }

        public void SetSFX()
        {
            SoundManager.instance.SetSFX(SFXSlider.value);
            setting.SFX = SFXSlider.value;
            SaveSetting(PlayerPrefKeys.SET_SFX, SFXSlider.value);
        }

        private void LoadSettings()
        {
            setting.BGM = PlayerPrefs.GetFloat(PlayerPrefKeys.SET_BGM, 0.5f);
            setting.SFX = PlayerPrefs.GetFloat(PlayerPrefKeys.SET_SFX, 0.5f);

            SoundManager.instance.SetBGM(setting.BGM);
            SoundManager.instance.SetSFX(setting.BGM);
            musicSlider.value = setting.BGM;
            SFXSlider.value = setting.BGM;
        }

        private void SaveSetting(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }
    }

}

