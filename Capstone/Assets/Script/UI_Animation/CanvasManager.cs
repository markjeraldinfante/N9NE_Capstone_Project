using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasManager : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject secondButton;
    public bool isForMenu;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    private void OnDisable()
    {
        if (isForMenu)
        {
            if (secondButton != null)
            {
                EventSystem.current.SetSelectedGameObject(secondButton);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

    }
    private void OnDestroy()
    {
        if (isForMenu)
        {
            if (secondButton != null)
            {
                EventSystem.current.SetSelectedGameObject(secondButton);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

}
