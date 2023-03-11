using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator characterAnimation;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private bool isGrounded;
    [SerializeField] public bool isProne;
    public bool isFacingRight = true;

    private void Awake()
    {
        characterAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isProne = false;
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0);

        if (move > 0 && !isFacingRight)
        {
            FlipCharacter();
            //isGrounded = true;
        }
        else if (move < 0 && isFacingRight)
        {
            FlipCharacter();
            //isGrounded = true;
        }
        ProneWalkingCheck(isProne, move);
    }
    void ProneWalkingCheck(bool isProne, float moveValue)
    {
        if (moveValue != 0 && !isProne)
        {
            characterAnimation.SetBool("Walk", true);
            characterAnimation.SetBool("Prone", isProne);
            characterAnimation.ResetTrigger("isProning");
        }
        else if (moveValue != 0 && isProne)
        {

            characterAnimation.SetBool("Prone", isProne);
            characterAnimation.SetBool("Walk", false);
            characterAnimation.SetTrigger("isProning");
        }
        else
        {
            characterAnimation.SetBool("Walk", false);
            characterAnimation.ResetTrigger("isProning");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isProne)
        {
            characterAnimation.SetBool("Jump", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else
        {
            characterAnimation.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isProne = true;
            ProneCheck(isProne);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isProne = false;
            ProneCheck(isProne);
        }

    }
    void ProneCheck(bool checkProne)
    {
        if (!isProne)
        {
            characterAnimation.SetTrigger("standProne");
        }
        characterAnimation.SetBool("Prone", isProne);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
private void OnCollisionStay(Collision collision)
{
    if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
}
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
