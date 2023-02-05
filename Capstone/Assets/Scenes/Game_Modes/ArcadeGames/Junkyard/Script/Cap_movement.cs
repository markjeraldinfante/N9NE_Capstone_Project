using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap_movement : MonoBehaviour
{
   private float speed = 50f;
   private Rigidbody2D mybody;
    // Start is called before the first frame update

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector2 vel = mybody.velocity;
       vel.x = Input.GetAxis("Horizontal") * speed;
       mybody.velocity = vel;

    }
}
