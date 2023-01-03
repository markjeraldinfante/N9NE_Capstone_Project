using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform cam;
    [SerializeField] public float camRotateValue = 5f;
    private Vector3 vector3 = Vector3.zero;

    private void Start()
    {
        LeanTween.reset();

    }
    private void FixedUpdate()
    {

        float camRotation = Input.GetAxis("Horizontal") * camRotateValue;
        //LeanTween.init(900);
        //.125f
        LeanTween.rotateY(cam.transform.gameObject, camRotation, .125f);
        // cam.eulerAngles = new Vector3(0f, camRotation, 0f);


    }

}
