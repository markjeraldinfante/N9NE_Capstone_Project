using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonSFX : MonoBehaviour
{
    public void ButtonCLICK()
    {
        somnium.SoundManager.instance.PlaySFX("ButtonClick");
    }
}
