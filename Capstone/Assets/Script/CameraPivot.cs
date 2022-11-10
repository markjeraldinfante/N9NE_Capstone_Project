using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
     public Transform cam;
     [SerializeField] public float camRotateValue = 5f;

    private void Start()
    {
        LeanTween.reset();
    }
    void LateUpdate()
    {

        float camRotation = Input.GetAxis("Horizontal")*camRotateValue;
        //LeanTween.init(900);
        LeanTween.rotateY(cam.transform.gameObject, camRotation, .125f);

    }
   
}
