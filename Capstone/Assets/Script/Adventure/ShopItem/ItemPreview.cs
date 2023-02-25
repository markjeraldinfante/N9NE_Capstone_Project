using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemPreview : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image itemImage;
    public TextMeshProUGUI itemDetails;
    public TextMeshProUGUI itemLevel;
    public TextMeshProUGUI itemDamage;
    public TextMeshProUGUI itemAttackSpeed;
    public Button button;
    public TextMeshProUGUI buttonText;


    public void DisplayItem(string itemName, Sprite itemImage, string itemDetails, string itemLevel,
    string itemDamage, string itemAttackSpeed, string itemUpgradeCost, bool isMaxLevel)
    {
        this.itemName.text = itemName;
        this.itemImage.sprite = itemImage;
        this.itemDetails.text = itemDetails;
        this.itemLevel.text = "Level : " + itemLevel;
        this.itemDamage.text = "Damage: " + itemDamage;
        this.itemAttackSpeed.text = "Attack Speed: " + itemAttackSpeed;
        buttonText.text = "Upgrade Cost: " + itemUpgradeCost;
        if (!isMaxLevel)
        {
            button.enabled = true;
        }
        else
        {
            button.enabled = false;
            buttonText.text = "MAX LEVEL";
        }

    }


}
