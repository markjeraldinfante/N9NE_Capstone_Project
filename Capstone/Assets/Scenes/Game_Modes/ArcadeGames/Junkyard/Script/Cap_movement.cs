using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap_movement : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vel = rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = vel;

    }
}
