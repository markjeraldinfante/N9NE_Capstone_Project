using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace somnium
{ 
public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    [SerializeField] public AudioMixerGroup BGM, SFX;
    [SerializeField] AudioSource SFXSource, BGMSource;
    [SerializeField] Sounds[] BG_music;
    [SerializeField] Sounds[] sounds_FX;
    [SerializeField] public float musicVolume = 1f;


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
        private void Start()
    {
        if (PlayerPrefs.HasKey("_BGM")) BGM.audioMixer.SetFloat("BGM", PlayerPrefs.GetFloat("_BGM"));
        if (PlayerPrefs.HasKey("_SFX")) SFX.audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("_SFX"));
    }
    public void SetSFX(float value)
    {
        SFX.audioMixer.SetFloat("SFX", value);
        PlayerPrefs.SetFloat("_SFX", value);
    }
    public void SetBGM(float value)
    {
        SFX.audioMixer.SetFloat("BGM", value);
        PlayerPrefs.SetFloat("_BGM", value);
    }
    #endregion

}
}

