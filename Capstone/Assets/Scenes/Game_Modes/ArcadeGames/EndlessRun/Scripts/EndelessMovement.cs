using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndelessMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float horizontalMovement = 4f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        float hAxis = Input.GetAxisRaw("Horizontal");

        if (hAxis < 0)
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalMovement);
            }
        }
        else if (hAxis > 0)
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalMovement);
            }
        }

    }
}
