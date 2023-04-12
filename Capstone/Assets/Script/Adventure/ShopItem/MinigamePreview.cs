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
        buyButton.onClick.AddListener(() => DisplayMinigame(selectedMinigameData));

    }
    public void DisplayMinigame(MiniGameData miniGameData)
    {
        errorMessage.text = "";
        selectedMinigameData = miniGameData;
        minigameName.text = miniGameData.miniGameName;
        minigameImage.sprite = miniGameData.miniGameImage;
        minigameDescription.text = miniGameData.miniGameDescription;
        buyButtonText.text = "Purchase Cost: " + miniGameData.GetMinigameCost();
        if (miniGameData.isBought)
        {
            buyButton.enabled = false;
            buyButtonText.text = "Purchased";
        }
        else
        {
            buyButton.enabled = true;
        }
    }



}
