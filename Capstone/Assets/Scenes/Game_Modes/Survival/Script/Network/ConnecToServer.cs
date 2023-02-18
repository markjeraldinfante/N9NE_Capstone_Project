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
        PhotonNetwork.NickName = PlayerPrefs.GetString(PlayerPrefKeys.PLAYER_NICKNAME);
        StartCoroutine(ConnectionDelay(Delay));
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        SceneManager.LoadScene("Lobby");
    }


    IEnumerator ConnectionDelay(float delay)
    {

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        yield return new WaitForSeconds(delay);
    }

}
