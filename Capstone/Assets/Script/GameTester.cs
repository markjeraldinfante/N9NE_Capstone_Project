using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKey(KeyCode.J))
        {
            SceneManager.LoadScene(5);
        }
    }
}
