using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    Rigidbody rb;
    bool facingRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        facingRight = true;
    }
    void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (move * runSpeed,rb.velocity.y, 0);
        if (move > 0 && !facingRight)
        {
            Flip();
            
        }

        else if (move < 0 && facingRight)
        {
            Flip();
            
        }
        else if (move == 0) 
        {
            
        };
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


  
}
