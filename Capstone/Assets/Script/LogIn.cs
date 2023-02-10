using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LogIn : MonoBehaviour
{

    public TMP_InputField UsernameInput;
    public TextMeshProUGUI UsernameView;
    public GameObject loginView;
    public GameObject playView;

    void Start()
    {
        if (PlayerPrefs.HasKey(PlayerPrefKeys.PLAYER_NICKNAME))
        {
            UsernameView.text = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);
            showPlay();
        }
    }

    public void OnButtonPressLogin()
    {
        if (UsernameInput.text.Length >= 1)
        {
            PlayerPrefs.SetString(PlayerPrefKeys.PLAYER_NICKNAME, UsernameInput.text);
            UsernameView.text = UsernameInput.text;
        }
        showPlay();
    }

    public void OnButtonPressChange()
    {
        UsernameInput.text = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);
        showLogin();
    }

    private void showPlay()
    {
        loginView.SetActive(false);
        playView.SetActive(true);
    }
    private void showLogin()
    {
        loginView.SetActive(true);
        playView.SetActive(false);
    }
}


