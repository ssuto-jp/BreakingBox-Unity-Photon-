using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : Photon.MonoBehaviour
{

    public void ConnectPhoton()
    {
        Debug.Log("サーバーに接続しています。");
        PhotonNetwork.ConnectUsingSettings("v1.0");
    }

    private void OnConnectedToMaster()
    {
        Debug.Log("サーバーへ接続しました。");
        PhotonNetwork.playerName = PlayerNetwork.Instance.Player_Id;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        Debug.Log("ロビーにはいりました。");
        Debug.Log(PhotonNetwork.playerName);
    }
}
