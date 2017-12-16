using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour
{

    public static PlayerNetwork Instance;
    public string Player_Id { get; private set; }

    private void Awake()
    {
        Instance = this;
        Player_Id = "#" + Random.Range(1000, 9999);
    }
}
