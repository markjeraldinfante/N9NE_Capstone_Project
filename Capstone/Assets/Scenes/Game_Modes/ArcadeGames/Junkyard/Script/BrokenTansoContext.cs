using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrokenTansoContext : MonoBehaviour
{
    public MiniGameManager junkYard;
    public TextMeshProUGUI brokenTansoText;

    private void Awake()
    {
        brokenTansoText.text = junkYard.tansoAward.ToString();
    }


}
