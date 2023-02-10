using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    [SerializeField] private int targetFPS = 120;

    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}
