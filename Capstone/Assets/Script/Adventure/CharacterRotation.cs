using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Transform trans;
    void OnMouseDrag()
    {
        float RotationChar = Input.GetAxis("Mouse X") * rotationSpeed;
        trans.Rotate(Vector3.down, RotationChar, Space.World);

        Debug.Log(RotationChar);

    }
}
