using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmarraMovement : MonoBehaviour
{
    public float movesSpeed = 600f;
    float movement = 0f;
    [SerializeField] bool isfacingRight;


    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -movesSpeed);

        if (movement > 0 && !isfacingRight)
        {
            isfacingRight = !isfacingRight;
        }
    }
}
