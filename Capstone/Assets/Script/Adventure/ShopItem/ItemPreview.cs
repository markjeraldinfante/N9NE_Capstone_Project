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
        var gameSystem = new GameSystem();
        if (DBHandler.instance.MainPlayerDB.TansoCount >= weaponData.GetItemCost(weaponData.ItemLevel))
        {
            weaponData.ItemLevel = PlayerPrefs.GetInt(weaponData.saveKey, 1);
            DBHandler.instance.MainPlayerDB.TansoCount -= weaponData.GetItemCost(weaponData.ItemLevel);
            gameSystem.Save(DBHandler.instance.MainPlayerDB.TansoCount, PlayerPrefKeys.TANSO);
            weaponData.Upgrade(() => DisplayItem(weaponData.ItemName, weaponData.ItemSprite, weaponData.ItemDescription, weaponData.ItemLevel.ToString(), weaponData.GetItemDamage(weaponData.ItemLevel).ToString(), weaponData.GetItemAttackSpeed(weaponData.ItemLevel).ToString(), weaponData.GetItemCost(weaponData.ItemLevel).ToString(), weaponData.IsMaxLevel(weaponData.IsMaxLevel(true)), weaponData));
            PlayerPrefs.SetInt(weaponData.saveKey, weaponData.ItemLevel);
        }
        else
            Debug.Log("Not enough tanso");
    }






}
