using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float moveSpeed = 600f;
    float movement = 0f;
    // public  Animator animator;
    private bool facingRight;
    private bool arrLeft;
    private bool arrRight;

    void Start()
    {
        facingRight = true;
        arrRight = false;
        arrLeft = false;
    }

    /*
        public void arrLeftDown()
        {
            arrLeft = true;
        }

        public void arrLeftUp()
        {
            arrLeft = false;
        }

        public void arrRightDown()
        {
            arrRight = true;

        }

        public void arrRightUp()
        {
            arrRight = false;
        }

    */

    void Update()
    {
        //animator.SetFloat("Speed", Mathf.Abs(movement));
        movement = Input.GetAxisRaw("Horizontal");
        //MovementPlayer();


    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime);
        // Flip(movement);
        //transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime* -movementSpeed);
    }
    /*
        private void MovementPlayer()
        {
            if (arrLeft)
            {
                movement = -moveSpeed;
            }

            else if (arrRight)
            {
                movement = moveSpeed;
            }

            else
            {
                movement = 0;
            }
        }

    */

    /*
        //facing left at right ng character
        private void Flip(float movement)
        {
            if (movement > 0 && !facingRight || movement < 0 && facingRight)
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;

                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    */

}
