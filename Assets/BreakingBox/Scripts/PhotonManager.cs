using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : Photon.MonoBehaviour
{
    [SerializeField] private GameObject player;
    private const string Scene_Name = "Play";

    private void Start()
    {
        SceneManager.sceneLoaded += OnLoadedScene;
    }

    public void ConnectPhoton()
    {
        PhotonNetwork.ConnectUsingSettings("v1.0");
        Debug.Log("サーバーに接続しています。");
    }

    private void OnJoinedLobby()
    {
        Debug.Log("ロビーにはいりました。");
    }

    public void OnClick_CreateRoom()
    {
        PhotonNetwork.playerName = PlayerNetwork.Instance.Player_Id;
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = 2,
            IsOpen = true,
            IsVisible = true,
        };

        PhotonNetwork.JoinOrCreateRoom("Room1", roomOptions, null);
        Debug.Log("ルームを作成しました。");
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        Debug.Log($"ルーム作成失敗しました。: (codeAndMessage[1])");
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.isMessageQueueRunning = false;
        SceneManager.LoadScene(Scene_Name);
        Debug.Log("ルームにはいりました。");
    }

    private void OnLoadedScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        PhotonNetwork.isMessageQueueRunning = true;

        if (scene.name == Scene_Name)
        {
            PhotonNetwork.Instantiate(player.name, Vector3.zero, Quaternion.identity, 0);
        }
    }
}
