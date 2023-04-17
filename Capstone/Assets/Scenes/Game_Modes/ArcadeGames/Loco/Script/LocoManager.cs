using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoManager : MonoBehaviour
{
    public GameObject deathUI;

    private void OnEnable()
    {
        locoEnemy.locoDeath += ShowDeathUI;
    }
    private void OnDisable()
    {
        locoEnemy.locoDeath -= ShowDeathUI;
    }
    private void OnDestroy()
    {
        locoEnemy.locoDeath -= ShowDeathUI;
    }

    private void ShowDeathUI()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
