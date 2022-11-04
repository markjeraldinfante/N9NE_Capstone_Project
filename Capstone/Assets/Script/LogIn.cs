using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogIn : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private Text welcomeText;
    [SerializeField] private Text usernameText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button enterButton;
    [HideInInspector] public string userName;
    

    void Awake()
    {
   
       if (PlayerPrefs.HasKey("username"))
        {
            // kapag may value na ung username
            usernameText.text = PlayerPrefs.GetString("username");
            usernameText.gameObject.SetActive(true);
            welcomeText.gameObject.SetActive(true);
            usernameInput.gameObject.SetActive(false);
            enterButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);

        }

        else
        {
            // kapag wala pang value ung username
            usernameText.gameObject.SetActive(false);
            welcomeText.gameObject.SetActive(false);
            usernameInput.gameObject.SetActive(true);
            enterButton.gameObject.SetActive(true);
            playButton.gameObject.SetActive(false);
        }
    }

    public void EnterGame()
    {
        userName = usernameInput.text;
        usernameText.text = userName;
        PlayerPrefs.SetString("username", userName);
        usernameText.gameObject.SetActive(true);
        welcomeText.gameObject.SetActive(true);
        usernameInput.gameObject.SetActive(false);
        enterButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteKey("username");
        }
    }
}
