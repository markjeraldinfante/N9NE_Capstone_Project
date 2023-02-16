using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bato : MonoBehaviour
{
   private float speed = 25f;

   [SerializeField] Rigidbody rb;

   private void FixedUpdate()
   {
    rb.velocity = Vector3.right * speed;

   }

   private void OnCollisionEnter(Collision collision)
   {
    if (collision.gameObject.CompareTag("Enemy"))
    {
        gameObject.SetActive(false);

    }


   }
}
