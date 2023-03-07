using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TansoManager : MonoBehaviour
{
    public TextMeshProUGUI[] tansoHolder;
    private void Awake()
    {
        tansoHolder[0].text = DBHandler.instance.MainPlayerDB.TansoCount.ToString();
        tansoHolder[1].text = "Tanso: " + DBHandler.instance.MainPlayerDB.TansoCount.ToString();
        DBHandler.instance.newValueTanso += UpdateTanso;
    }
    void UpdateTanso(int newValue)
    {

        tansoHolder[0].text = newValue.ToString();
        tansoHolder[1].text = "Tanso: " + newValue.ToString();

    }

}
