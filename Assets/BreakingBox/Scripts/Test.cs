using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    [SerializeField] private Text countDownText;
    [SerializeField] private float totalTime = 20;

    void Start()
    {

    }

    void Update()
    {
        if (PhotonNetwork.room.PlayerCount == 2)
        {
            CountDownTimer();
        }

    }

    private void CountDownTimer()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0)
        {
            totalTime = 0;
        }
        countDownText.text = totalTime.ToString("F2");
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(totalTime);
        }
        else
        {
            totalTime = (float)stream.ReceiveNext();
        }
    }
}
