using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    private void Awake()
    {
        LeanTween.reset();
    }
    public void Open()
    {
        // LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.8f).setEaseOutBack();
        transform.LeanScale(Vector3.one, 0.8f).setEaseOutBack();
        Debug.Log("pop");
    }
    public void Close()
    {
        transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
        // LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.8f).setEaseOutBack();
    }

}
