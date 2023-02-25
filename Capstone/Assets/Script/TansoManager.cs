using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TansoManager : MonoBehaviour
{
    public TextMeshProUGUI[] tansoHolder;

    void Awake()
    {

        tansoHolder[0].text = DBHandler.instance.MainPlayerDB.TansoCount.ToString();
        tansoHolder[1].text = "Tanso: " + DBHandler.instance.MainPlayerDB.TansoCount.ToString();

    }

}
