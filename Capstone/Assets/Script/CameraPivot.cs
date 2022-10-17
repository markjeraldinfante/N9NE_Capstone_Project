using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
     Transform cam;
    [SerializeField] private float camRotateValue = 5f;

    private void Awake()
    {
        cam = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        float camRotation = Input.GetAxis("Horizontal") * camRotateValue;
        cam.rotation = Quaternion.Euler(0f, camRotation, 0f);
    }


}
