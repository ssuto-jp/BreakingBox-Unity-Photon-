using UnityEngine;
using UnityEngine.UI;

public class PlayerNameUI : Photon.MonoBehaviour
{
    private GameObject namePlate;
    [SerializeField] private Text nameText;

    private void Start()
    {
        namePlate = nameText.transform.parent.gameObject;
        photonView.RPC("SetName", PhotonTargets.All, PhotonNetwork.playerName);
    }

    private void LateUpdate()
    {
        namePlate.transform.rotation = Camera.main.transform.rotation;
    }

    [PunRPC]
    private void SetName(string name) => nameText.text = name;
}
