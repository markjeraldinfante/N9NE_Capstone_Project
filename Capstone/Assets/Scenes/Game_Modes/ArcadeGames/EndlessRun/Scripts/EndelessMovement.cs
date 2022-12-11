using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndelessMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float horizontalMovement = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalMovement);
            }
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(this.gameObject.transform.position.x < LevelBoundary.rightSide) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalMovement * -1);
            }
            
        }
    }
}
