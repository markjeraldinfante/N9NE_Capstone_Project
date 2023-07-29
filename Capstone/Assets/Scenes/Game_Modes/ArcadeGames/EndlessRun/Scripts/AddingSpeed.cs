using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingSpeed : MonoBehaviour
{
    public float addingSpeed = 1f;
    public DistanceDisplay distance;
    EndelessMovement move;
    // Start is called before the first frame update
    void Awake()
    {
        move = GetComponent<EndelessMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance.disRun > 1)
        {
            move.moveSpeed += .001f;
        }
    }

}