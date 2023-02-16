using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnecToServer : MonoBehaviourPunCallbacks
{
    public float Delay = 5f;
    private void Start()
    {
        StartCoroutine(ConnectionDelay(Delay));
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator ConnectionDelay(float delay)
    {

        PhotonNetwork.ConnectUsingSettings();
        yield return new WaitForSeconds(delay);
    }

}
