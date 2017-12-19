using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    [SerializeField] private Text countDownText;
    [SerializeField] private Text boxCountText;
    [SerializeField] private GameObject clearText;
    [SerializeField] private GameObject timeOutText;
    [SerializeField] private float totalTime = 20;
    public static int BoxCount;

    void Start()
    {
        BoxCount = GameObject.FindGameObjectsWithTag("Box").Length;
    }

    void Update()
    {
        if (PhotonNetwork.room.PlayerCount == 2)
        {
            CountDownTimer();
            SetClear();
        }
        countDownText.text = totalTime.ToString("F2");
        boxCountText.text = (BoxCount).ToString();
    }

    private void CountDownTimer()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0 && BoxCount > 0)
        {
            totalTime = 0;
            timeOutText.SetActive(true);
        }
    }

    private void SetClear()
    {
        if (BoxCount == 0)
        {
            totalTime = 60;
            clearText.SetActive(true);

        }
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
