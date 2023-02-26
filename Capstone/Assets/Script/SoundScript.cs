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

        }

        public void SetSFX()
        {
            SoundManager.instance.SetSFX(SFXSlider.value);
            setting.SFX = SFXSlider.value;

        }

        private void LoadSettings()
        {
            setting.BGM = SoundManager.instance.BGMSource.volume;
            setting.SFX = SoundManager.instance.SFXSource.volume;

            musicSlider.value = setting.BGM;
            SFXSlider.value = setting.SFX;
        }
    }

}

