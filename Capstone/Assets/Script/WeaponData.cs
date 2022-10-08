using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
   [SerializeField] private string WeaponName;
   [SerializeField] private string WeaponDescription;
   [SerializeField] private Sprite WeaponSprite;
   [SerializeField] private int WeaponDamage;
   [SerializeField] private int WeaponLevel;

}
