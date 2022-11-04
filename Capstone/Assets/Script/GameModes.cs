using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModes:MonoBehaviour
{
  
    public void OnButtonClickedStoryMode()
    {
        SceneManager.LoadScene(3);
    }

    public void OnButtonClickedBack()
    {
        SceneManager.LoadScene(1);
    }

}
