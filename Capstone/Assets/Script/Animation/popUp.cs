using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{
    public GameObject raylight;
    public int loopTime = 2;

    void OnEnable()
    {
        LeanTween.cancel(raylight);
        LeanTween.rotateAround(raylight, Vector3.back, 360f, loopTime).setLoopClamp().setIgnoreTimeScale(true);
    }
    private void OnDisable()
    {
        LeanTween.cancel(raylight);
    }

}
