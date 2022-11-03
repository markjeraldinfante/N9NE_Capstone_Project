using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpForce;
    private Rigidbody rb;
    [SerializeField] bool isfacingRight;
    [SerializeField] bool isGrounded;
 

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isfacingRight = true;
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (move * runSpeed,rb.velocity.y, 0);
        if (move > 0 && !isfacingRight)
        {
            StartCoroutine(Delayflip());
            isfacingRight = !isfacingRight;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        else if (move < 0 && isfacingRight)
        {
            StartCoroutine(Delayflip());
            isfacingRight = !isfacingRight;
            transform.eulerAngles = new Vector3(0f, -180f, 0f); //flip the character on its x axis
        }
        else if (move == 0) 
        {
            
        };

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Vector3 jump = new Vector3(0f, 2f, 0f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    #region Checker
    void Flip()
    {
        isfacingRight = !isfacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    #endregion

    IEnumerator Delayflip()
    {
        yield return new WaitForSeconds(5f);
    }
}
