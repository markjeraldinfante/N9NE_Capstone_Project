using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float speed = 5f; // speed of character movement
    public float rotationSpeed = 100f; // speed of character rotation

    private float horizontalInput; // input for horizontal movement
    private float verticalInput; // input for vertical movement
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Get input for horizontal and vertical movement
        horizontalInput = Input.GetAxisRaw("Horizontal 1");
        verticalInput = Input.GetAxisRaw("Vertical 1");

        // Move the character horizontally and vertically
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Rotate the character based on input
        if (movement != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
            animator.SetBool("Walk", false);
    }
}
