using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI playerName;
    Image backgroundImage;
    public Color highlightColor;
    public GameObject leftArrowButton, rightArrowButton;
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public CharacterData[] avatars;
    private List<CharacterData> unlockedCharacters = new List<CharacterData>();
    Photon.Realtime.Player player;
    private void Start()
    {
        unlockedCharacters.AddRange(Array.FindAll(avatars, c => c.isUnlocked));
        int selectedAvatar = PlayerPrefs.GetInt(player.NickName, 0);
        playerProperties["playerAvatar"] = selectedAvatar;
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    private void Awake()
    {

        backgroundImage = GetComponent<Image>();
    }
    public void SetPlayerInfo(Photon.Realtime.Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(_player);
    }
    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }
    public void OnClickPreviousArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = unlockedCharacters.Count - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void OnClickNextArrow()
    {
        if ((int)playerProperties["playerAvatar"] == unlockedCharacters.Count - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player.Equals(targetPlayer))
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Photon.Realtime.Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            int avatarIndex = (int)player.CustomProperties["playerAvatar"];
            if (avatarIndex < unlockedCharacters.Count)
            {
                playerAvatar.sprite = unlockedCharacters[avatarIndex].survivalSplashArt;
                playerProperties["playerAvatar"] = avatarIndex;
                PlayerPrefs.SetInt(player.NickName, avatarIndex); // Store selection in PlayerPrefs using player's NickName as key
            }
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
            PlayerPrefs.SetInt(player.NickName, 0); // Store default selection in PlayerPrefs using player's NickName as key
        }
    }


}
