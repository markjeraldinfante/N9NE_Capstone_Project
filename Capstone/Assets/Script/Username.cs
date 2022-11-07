using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Username : MonoBehaviour
{
    private TextMeshProUGUI username;
    private void Awake()
    {
      username = GetComponentInChildren<TextMeshProUGUI>();
      username.text = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);
    }
}
