using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public List<WeaponData> weapon = new List<WeaponData>();
    public Transform weaponSelectionContent;
    public GameObject weaponItem;
    public WeaponSlot weaponSlot;
    public float checkInterval;
    private void Start()
    {
        WeaponLists();
    }

    public void WeaponLists()
    {
        foreach (var item in weapon)
        {
            weaponSlot.weaponData = item;
            weaponSlot.itemName = item.ItemName;
            weaponSlot.itemSprite = item.ItemSprite;
            weaponSlot.itemDetails = item.ItemDescription;
            weaponSlot.itemLevel = item.ItemLevel;
            weaponSlot.itemDamage = item.GetItemDamage(weaponSlot.itemLevel);
            weaponSlot.itemAttackSpeed = item.GetItemAttackSpeed(weaponSlot.itemLevel);
            weaponSlot.itemUpgradeCost = item.GetItemCost(weaponSlot.itemLevel);
            weaponSlot.isMaxLevel = item.IsMaxLevel(weaponSlot.isMaxLevel);

            GameObject gameObject = Instantiate(weaponItem, weaponSelectionContent);

            var _Name = gameObject.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var _Sprite = gameObject.transform.Find("ItemImage").GetComponent<Image>();

            _Name.text = weaponSlot.itemName;
            _Sprite.sprite = weaponSlot.itemSprite;
        }

    }

}
