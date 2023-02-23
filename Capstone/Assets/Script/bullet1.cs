using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAI : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Enemy hit!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No enemy hit.");
        }
    }

}
