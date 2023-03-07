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
    public TextMeshProUGUI errorMessage;


    private void Awake()
    {
        upgradeButton.onClick.AddListener(() => UpgradeItem(selectedWeaponData));

    }
    public void DisplayItem(WeaponData weaponData)
    {
        errorMessage.text = "";
        selectedWeaponData = weaponData;
        itemName.text = weaponData.ItemName;
        itemImage.sprite = weaponData.ItemSprite;
        itemDetails.text = weaponData.ItemDescription;
        itemLevel.text = "Level: " + weaponData.ItemLevel.ToString();
        itemDamage.text = "Damage: " + weaponData.GetItemDamage(weaponData.ItemLevel).ToString();
        itemAttackSpeed.text = "Attack Speed: " + weaponData.GetItemAttackSpeed(weaponData.ItemLevel).ToString();
        upgradeButtonText.text = "Upgrade Cost: " + weaponData.GetItemCost(weaponData.ItemLevel).ToString();
        if (weaponData.IsMaxLevel(weaponData.IsMaxLevel(true)))
        {
            upgradeButton.enabled = false;
            upgradeButtonText.text = "MAX LEVEL";
        }
        else
        {
            upgradeButton.enabled = true;
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
            weaponData.Upgrade(() => DisplayItem(weaponData));
            PlayerPrefs.SetInt(weaponData.saveKey, weaponData.ItemLevel);
        }
        else
        {
            Debug.Log("Not enough tanso");
            errorMessage.text = "Not enough tanso";
        }
    }







}
