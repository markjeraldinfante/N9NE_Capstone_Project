using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppVersion : MonoBehaviour
{
    public TextMeshProUGUI versionText;
    void Awake()
    {
        versionText.text = "Version " + Application.version + "  © " + Application.companyName + " 2023";
    }

}
