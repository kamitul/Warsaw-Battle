using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public PlayerData Data { get => playerData; }

    public void SetData(PlayerData data)
    {
        playerData = data;
    }
}
