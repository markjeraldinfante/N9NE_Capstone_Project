using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemLevel : MonoBehaviour
{
    public WeaponData slingshot, shovel, meter_stick, slippers;

    private void Awake()
    {
        slingshot.ItemLevel = PlayerPrefs.GetInt(slingshot.saveKey, 1);
        shovel.ItemLevel = PlayerPrefs.GetInt(shovel.saveKey, 1);
        meter_stick.ItemLevel = PlayerPrefs.GetInt(meter_stick.saveKey, 1);
        slippers.ItemLevel = PlayerPrefs.GetInt(slippers.saveKey, 1);
    }
}
