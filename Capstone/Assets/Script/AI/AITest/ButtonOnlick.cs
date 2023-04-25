using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonOnlick : MonoBehaviour
{
    public Button myButton;
    private void Start()
    {
        myButton = GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Attack") && myButton.enabled == true)
        {
            this.myButton.onClick.Invoke();
        }

    }
}
