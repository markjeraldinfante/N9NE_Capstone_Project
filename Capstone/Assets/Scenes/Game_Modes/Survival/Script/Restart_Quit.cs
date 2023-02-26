using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart_Quit : MonoBehaviour
{
   public void Restart()
    {
        SceneManager.LoadScene("SurvivalScene");
    }

   
}
