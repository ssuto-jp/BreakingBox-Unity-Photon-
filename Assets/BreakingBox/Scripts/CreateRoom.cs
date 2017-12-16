using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{

    public void OnClick_CreateRoom()
    {
        PhotonNetwork.playerName = PlayerNetwork.Instance.Player_Id;
        Debug.Log(PhotonNetwork.playerName);
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = 2,
            IsOpen = true,
            IsVisible = true,
        };

        PhotonNetwork.JoinOrCreateRoom(PhotonNetwork.playerName, roomOptions, null);
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        Debug.Log($"create room failed: (codeAndMessage[1]");
    }

    private void OnJoinedRoom()
    {
        Debug.Log("ルームにはいりました。");
        PhotonNetwork.LoadLevel("Play");
    }

}
