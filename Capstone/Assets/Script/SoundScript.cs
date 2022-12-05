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

            if (!PlayerPrefs.HasKey("SetBGM") && !PlayerPrefs.HasKey("SetSFX"))
            {
                musicSlider.value = 0.8f;
                SFXSlider.value = 0.8f;

                SetBGM();
                SetSFX();
            }
            else
            {
                musicSlider.value = PlayerPrefs.GetFloat("SetBGM");
                SFXSlider.value = PlayerPrefs.GetFloat("SetSFX");
                SoundManager.instance.SetBGM(PlayerPrefs.GetFloat("SetBGM"));
                SoundManager.instance.SetSFX(PlayerPrefs.GetFloat("SetSFX"));
            }


        }
        public void SetBGM()
        {
            SoundManager.instance.SetBGM(musicSlider.value);
            PlayerPrefs.SetFloat("SetBGM", musicSlider.value);


        }


        public void SetSFX()
        {
            SoundManager.instance.SetSFX(SFXSlider.value);
            PlayerPrefs.SetFloat("SetSFX", SFXSlider.value);
        }
      

    }
}
