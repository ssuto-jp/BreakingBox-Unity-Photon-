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

    private void OnJoinedLobby()
    {
        Debug.Log("ロビーにはいりました。");
    }
}
