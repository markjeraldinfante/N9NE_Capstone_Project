using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MinigamePreview : MonoBehaviour
{
    public MiniGameData selectedMinigameData;
    public TextMeshProUGUI minigameName;
    public Image minigameImage;
    public TextMeshProUGUI minigameDescription;
    public Button buyButton;
    public TextMeshProUGUI buyButtonText;
    public TextMeshProUGUI errorMessage;


    private void Awake()
    {
        buyButton.onClick.AddListener(() => PurchaseMiniGame(selectedMinigameData));

    }
    public void DisplayMinigame(MiniGameData miniGameData)
    {
        errorMessage.text = "";
        selectedMinigameData = miniGameData;
        minigameName.text = miniGameData.miniGameName;
        minigameImage.sprite = miniGameData.miniGameImage;
        minigameDescription.text = miniGameData.miniGameDescription;
        buyButtonText.text = "Purchase Cost: " + miniGameData.GetMinigameCost();
        if (miniGameData.IsBought)
        {
            buyButton.enabled = false;
            buyButtonText.text = "Purchased";
        }
        else
        {
            buyButton.enabled = true;
        }
    }
    public void PurchaseMiniGame(MiniGameData miniGameData)
    {
        var gameSystem = new GameSystem();
        if (DBHandler.instance.MainPlayerDB.TansoCount >= miniGameData.miniGameCost)
        {

            DBHandler.instance.MainPlayerDB.TansoCount -= miniGameData.miniGameCost;
            gameSystem.Save(DBHandler.instance.MainPlayerDB.TansoCount, PlayerPrefKeys.TANSO);
            miniGameData.Purchase(() => DisplayMinigame(miniGameData));
            SavingState.instance.SaveState();
        }
        else
        {
            Debug.Log("Not enough tanso");
            errorMessage.text = "Not enough tanso";
        }
    }


}
