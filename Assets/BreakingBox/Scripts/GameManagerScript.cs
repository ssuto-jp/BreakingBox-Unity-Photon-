using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] private Text countDownText;
    [SerializeField] private Text boxCountText;
    [SerializeField] private GameObject clearText;
    [SerializeField] private GameObject timeOutText;
    [SerializeField] private float totalTime = 20;
    public static int BoxCount;

    private void Start()
    {
        BoxCount = GameObject.FindGameObjectsWithTag("Box").Length;
    }

    private void Update()
    {
        if (PhotonNetwork.room.PlayerCount == 2)
        {
            CountDownTimer();
            SetClearText();
        }
        countDownText.text = totalTime.ToString("F2");
        boxCountText.text = (BoxCount).ToString();
    }

    //時間制限
    private void CountDownTimer()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0 && BoxCount > 0)
        {
            totalTime = 0;
            timeOutText.SetActive(true);
        }
    }

    //箱を全て破壊したらクリアテキスト表示
    private void SetClearText()
    {
        if (BoxCount == 0)
        {
            totalTime = 60;
            clearText.SetActive(true);
        }
    }

    //プレイヤー間での制限時間の同期
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
