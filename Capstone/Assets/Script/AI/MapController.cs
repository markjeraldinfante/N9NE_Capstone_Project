using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal 1");
        float verticalInput = Input.GetAxisRaw("Vertical 1");


        if (horizontalInput == 0f)
        {
            horizontalInput = Input.GetAxisRaw("JoyStickX");
        }

        if (verticalInput == 0f)
        {
            verticalInput = -Input.GetAxisRaw("JoyStickY");
        }

        // Move the character
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            animator.SetBool("Walk", true);
            Vector3 movement = new Vector3(horizontalInput, 0f, -verticalInput).normalized;

            movement = new Vector3(movement.z, 0f, movement.x);
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
