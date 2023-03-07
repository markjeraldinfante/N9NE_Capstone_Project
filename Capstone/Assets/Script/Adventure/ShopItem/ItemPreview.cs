using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemPreview : MonoBehaviour
{
    public PlayerDB playerDB;
    public WeaponData selectedWeaponData;
    public TextMeshProUGUI itemName;
    public Image itemImage;
    public TextMeshProUGUI itemDetails;
    public TextMeshProUGUI itemLevel;
    public TextMeshProUGUI itemDamage;
    public TextMeshProUGUI itemAttackSpeed;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeButtonText;

    private void Awake()
    {
        upgradeButton.onClick.AddListener(() => UpgradeItem(selectedWeaponData));

    }
    public void DisplayItem(string itemName, Sprite itemImage, string itemDetails, string itemLevel,
    string itemDamage, string itemAttackSpeed, string itemUpgradeCost, bool isMaxLevel, WeaponData weaponData)
    {
        selectedWeaponData = weaponData;
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
    public void UpgradeItem(WeaponData weaponData)
    {
        if (playerDB.TansoCount >= weaponData.GetItemCost(weaponData.ItemLevel))
        {
            playerDB.TansoCount -= weaponData.GetItemCost(weaponData.ItemLevel);
            weaponData.Upgrade(() => DisplayItem(selectedWeaponData.ItemName, selectedWeaponData.ItemSprite, selectedWeaponData.ItemDescription, selectedWeaponData.ItemLevel.ToString(), selectedWeaponData.GetItemDamage(selectedWeaponData.ItemLevel).ToString(), selectedWeaponData.GetItemAttackSpeed(selectedWeaponData.ItemLevel).ToString(), selectedWeaponData.GetItemCost(selectedWeaponData.ItemLevel).ToString(), selectedWeaponData.IsMaxLevel(selectedWeaponData.IsMaxLevel(true)), selectedWeaponData));
        }
        else
            Debug.Log("Not enough tanso");
    }






}
