using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public GameObject waitingForOtherPlayer;
    public bool DevMode;

    private bool isConnecting;
    private void Awake()
    {
        waitingForOtherPlayer.SetActive(false);
    }
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        isConnecting = true;
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        isConnecting = true;
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created.");
    }

    public override void OnJoinedRoom()
    {
        if (DevMode)
        {
            PhotonNetwork.LoadLevel(8);
            return;
        }
        if (isConnecting)
        {
            Debug.Log("Room joined.");
            StartCoroutine(WaitForPlayers());
        }
    }

    private IEnumerator WaitForPlayers()
    {
        waitingForOtherPlayer.SetActive(true);

        // Wait for both the host and client to connect to the room
        while (PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            yield return null;
        }

        Debug.Log("Players connected. Loading scene...");
        PhotonNetwork.LoadLevel(8);
    }
}
