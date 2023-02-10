using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] stringArray;
    public float displayTime = 0.4f;

    private int currentIndex = 0;

    void Start()
    {
        textMeshPro.text = stringArray[currentIndex];
        InvokeRepeating("NextString", displayTime, displayTime);
    }

    void NextString()
    {
        currentIndex = (currentIndex + 1) % stringArray.Length;
        textMeshPro.text = stringArray[currentIndex];
    }
}
