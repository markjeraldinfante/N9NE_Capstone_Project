using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
  public string ItemName;
  public Sprite ItemSprite;
  public string ItemDescription;
  public int ItemLevel;
  public int[] ItemDamage;
  public int[] ItemUpgradeCost;
  public float[] ItemAttackSpeed;

}
