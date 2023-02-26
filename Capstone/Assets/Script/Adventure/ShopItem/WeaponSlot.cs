using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class WeaponSlot : MonoBehaviour
{
    public Button btn;
    public string itemName;
    public Sprite itemSprite;
    public string itemDetails;
    public int itemLevel;
    public int itemUpgradeCost;
    public int itemDamage;
    public float itemAttackSpeed;
    public bool isMaxLevel;
    [SerializeField] private ItemPreview itemPreview;

    void Awake()
    {
        itemPreview = GameObject.Find("AdventureManager").GetComponent<ItemPreview>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ButtonOnClick);
    }

    void ButtonOnClick()
    {
        itemPreview.DisplayItem(itemName, itemSprite, itemDetails, itemLevel.ToString(), itemDamage.ToString(), itemAttackSpeed.ToString(), itemUpgradeCost.ToString(), isMaxLevel);
    }
}
