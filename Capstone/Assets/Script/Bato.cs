using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bato : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

        }
    }
}
