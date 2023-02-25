using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TansoManager : MonoBehaviour
{
    public TextMeshProUGUI[] tansoHolder;

    void Awake()
    {
        for (int i = 0; i < tansoHolder.Length; i++)
        {
            tansoHolder[i].text = DBHandler.instance.MainPlayerDB.TansoCount.ToString();
        }
    }

}
