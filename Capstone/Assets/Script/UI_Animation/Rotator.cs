using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float loopTime;
    void Awake()
    {
        //LeanTween.rotateAround(obj, Vector3.back, 360f, loopTime).setLoopClamp().setIgnoreTimeScale(true);
        LeanTween.rotateAround(obj, Vector3.back, 360f, loopTime).setLoopClamp().setIgnoreTimeScale(true);
    }

}
