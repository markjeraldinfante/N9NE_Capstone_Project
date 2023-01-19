using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TansoManager : MonoBehaviour
{
    public TextMeshProUGUI tansoHolder;

    void Awake()
    {
        tansoHolder.text = DBHandler.instance.MainPlayerDB.TansoCount.ToString();
    }
    private void FixedUpdate()
    {

    }

}
