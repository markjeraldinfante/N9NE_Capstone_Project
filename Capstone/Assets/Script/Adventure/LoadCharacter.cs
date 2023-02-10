using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public delegate void OnShowCharacter();
    public static event OnShowCharacter showChar;


    private void OnEnable()
    {
        showChar?.Invoke();
    }

}
