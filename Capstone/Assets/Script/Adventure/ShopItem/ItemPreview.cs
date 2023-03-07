using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemPreview : MonoBehaviour
{
    public WeaponData selectedWeaponData;
    public TextMeshProUGUI itemName;
    public Image itemImage;
    public TextMeshProUGUI itemDetails;
    public TextMeshProUGUI itemLevel;
    public TextMeshProUGUI itemDamage;
    public TextMeshProUGUI itemAttackSpeed;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeButtonText;


    public void DisplayItem(string itemName, Sprite itemImage, string itemDetails, string itemLevel,
    string itemDamage, string itemAttackSpeed, string itemUpgradeCost, bool isMaxLevel, WeaponData weaponData)
    {
        this.selectedWeaponData = weaponData;
        this.itemName.text = itemName;
        this.itemImage.sprite = itemImage;
        this.itemDetails.text = itemDetails;
        this.itemLevel.text = "Level : " + itemLevel;
        this.itemDamage.text = "Damage: " + itemDamage;
        this.itemAttackSpeed.text = "Attack Speed: " + itemAttackSpeed;
        upgradeButtonText.text = "Upgrade Cost: " + itemUpgradeCost;
        if (!isMaxLevel)
        {
            upgradeButton.enabled = true;
        }
        else
        {
            upgradeButton.enabled = false;
            upgradeButtonText.text = "MAX LEVEL";
        }

    }


}
