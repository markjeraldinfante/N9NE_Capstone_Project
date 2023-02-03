using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuListener : MonoBehaviour
{
    public delegate void OnStartAnimation();
    public delegate void OffStartAnimation();
    public static event OnStartAnimation PopUpANim;
    public static event OffStartAnimation CloseAnim;
    public Button btnOpen, btnClose;
    public float Delay = 1f;

    private void Awake()
    {
        btnOpen.onClick.AddListener(OpenOption);
        btnClose.onClick.AddListener(CloseOption);
    }
    public void OpenOption()
    {
        PopUpANim?.Invoke();
    }
    public void CloseOption()
    {
        CloseAnim?.Invoke();
    }


}
