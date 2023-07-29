using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class PlayerFrame : MonoBehaviour
{
    [SerializeField]
    basePlayerSelect basePlayer;
    public Image frameAvatar;
    public Sprite[] avatars;
    public TextMeshProUGUI playerName;

    void Awake()
    {
        Fetch();
    }

    private void Fetch()
    {
        FetchName();
        FetchAvatar();
    }
    private void FetchName()
    {
        if (DBHandler.instance.MainPlayerDB.PlayerName == "")
        {
            playerName.text = "Player";
        }
        else
            playerName.text = DBHandler.instance.MainPlayerDB.PlayerName;
    }
    private void FetchAvatar()
    {
        switch (basePlayer.CharacterID)
        {
            case "1":
                frameAvatar.sprite = avatars[0];
                break;
            case "2":
                frameAvatar.sprite = avatars[1];
                break;
            case "3":
                frameAvatar.sprite = avatars[2];
                break;
            case "4":
                frameAvatar.sprite = avatars[3];
                break;

            default:
                frameAvatar.sprite = avatars[0];
                break;
        }
    }

}
