using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrokenTansoContext : MonoBehaviour
{
    public MiniGameManager junkYard;
    public TextMeshProUGUI brokenTansoText;
    public TextMeshProUGUI eventMessage;

    private void Awake()
    {

        brokenTansoText.text = junkYard.tansoAward.ToString();
        eventMessage.text = "";
    }
    public void ClearText()
    {
        eventMessage.text = "";
    }

    public void ExchangeCurrency()
    {

        if (junkYard.tansoAward >= 10)
        {
            junkYard.tansoAward -= 10;
            DBHandler.instance.MainPlayerDB.TansoCount += 1;

            eventMessage.text = "Exchange Successful!";
            eventMessage.color = Color.green;

            UpdateUI(DBHandler.instance.MainPlayerDB.TansoCount);
        }
        else
        {
            eventMessage.text = "Not enough Broken Tanso";
            eventMessage.color = Color.red;
        }
    }


    private void UpdateUI(int newTanso)
    {
        var gameSystem = new GameSystem();
        brokenTansoText.text = junkYard.tansoAward.ToString();
        gameSystem.Save(junkYard.tansoAward, PlayerPrefKeys.BROKEN_TANSO);
        DBHandler.instance.UpdateTanso(newTanso);
    }


}
