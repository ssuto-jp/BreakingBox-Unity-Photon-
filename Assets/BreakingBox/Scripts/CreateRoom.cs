using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{

    [SerializeField] private Text _roomName;
    public Text RoomName
    {
        get { return _roomName; }
    }

    public void OnClick_CreateRoom()
    {
        if (PhotonNetwork.CreateRoom(RoomName.text))
        {
            Debug.Log("ルーム作成成功");
            Debug.Log(RoomName.text);
        }
        else
        {
            Debug.Log("ルーム作成失敗");
        }
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        Debug.Log($"create room failed: (codeAndMessage[1]");
    }

    private void OnCreatedRoom()
    {
        Debug.Log("ルームを作成しました。");
    }
}
