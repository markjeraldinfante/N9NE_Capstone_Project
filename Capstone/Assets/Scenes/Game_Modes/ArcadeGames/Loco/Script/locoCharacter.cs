using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locoCharacter : MonoBehaviour
{
    public GameObject[] projectiles;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(projectiles[0], transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(projectiles[1], transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(projectiles[2], transform.position, Quaternion.identity);
        }

    }
}
