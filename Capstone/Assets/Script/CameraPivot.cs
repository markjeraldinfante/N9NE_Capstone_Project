using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform cam;
    [SerializeField] public float camRotateValue = 5f;
    [SerializeField] private float rotateDuration = 0.125f;
    private float currentRotation = 0f;
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Start()
    {
        LeanTween.reset();
    }

    private void FixedUpdate()
    {
        float targetRotation = Input.GetAxis("Horizontal") * camRotateValue;
        if (targetRotation != currentRotation)
        {
            LeanTween.cancel(cam.gameObject);
            LeanTween.rotateY(cam.gameObject, targetRotation, rotateDuration);
            currentRotation = targetRotation;
        }
    }
}

