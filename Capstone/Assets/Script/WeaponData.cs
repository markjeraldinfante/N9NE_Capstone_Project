using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string ItemName;
    public Sprite ItemSprite;
    public string ItemDescription;
    public int itemLevel;
    public int[] ItemDamage;
    public int[] ItemUpgradeCost;
    public int[] ItemUpgradeAmount; // new field
    public float[] ItemAttackSpeed;
    [SerializeField] private int maxLevel;
    public int ItemLevel
    {
        get { return itemLevel; }
        set { itemLevel = Mathf.Clamp(value, 1, maxLevel); }
    }
    public void Upgrade()
    {
        ItemLevel++;
        int level = ItemLevel - 1;

    }

    public int GetItemDamage(int level)
    {
        if (level > maxLevel)
        {
            return 0;
        }
        int damage = ItemDamage[level - 1];
        return damage;
    }
    public bool IsMaxLevel(bool isMaxLevel)
    {
        if (ItemLevel >= maxLevel)
        {
            return true;
        }
        else
            return false;
    }

    public int GetItemCost(int level)
    {
        if (level > maxLevel)
        {
            return 0;
        }
        else if (level == maxLevel)
        {
            return ItemUpgradeCost[ItemUpgradeCost.Length - 1];
        }
        else
        {
            int cost = ItemUpgradeCost[level - 1];
            return cost;
        }
    }


    public float GetItemAttackSpeed(int level)
    {
        if (level > maxLevel)
        {
            return 0.0f;
        }
        float attackSpeed = ItemAttackSpeed[level - 1];
        return attackSpeed;
    }
}
