using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class OnlineSpawn : MonoBehaviourPunCallbacks
{
    public PlayerSpawner spawner;
    public void Connection()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        if (PhotonNetwork.IsConnectedAndReady)
        { spawner.OnlineAssignAndInstantiateCharacter(); }

    }

}
