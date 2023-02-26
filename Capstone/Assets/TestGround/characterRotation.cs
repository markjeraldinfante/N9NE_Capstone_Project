using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    Transform tras;
    private void Awake()
    {
        tras = GetComponent<Transform>();
    }
    void Update()
    {
        tras.Rotate(new Vector3(0, 360, 0), rotationSpeed * Time.deltaTime);
    }
}
