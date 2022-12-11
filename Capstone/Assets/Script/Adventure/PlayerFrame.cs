using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFrame : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    // Start is called before the first frame update
    void Awake()
    {
        playerName.text = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
