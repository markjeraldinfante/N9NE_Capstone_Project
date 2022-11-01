using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuu : MonoBehaviour
{
    public GameObject optionScreen;
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);      
    }
    public void OpenOption()
    {
       optionScreen.SetActive(true);
    }
    public void CloseOption()
    {
        optionScreen.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");

    }

}
