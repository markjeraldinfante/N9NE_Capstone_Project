using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTester : MonoBehaviour
{
    public KeyCode key1;
    public KeyCode key2;
    public int build1;
    public int build2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key1))
        {
            SceneManager.LoadScene(build1);
        }
        if (Input.GetKey(key2))
        {
            SceneManager.LoadScene(build2);
        }
    }
}
