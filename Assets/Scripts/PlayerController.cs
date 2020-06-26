using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField]
    private PlayerData playerData;

    public PlayerData Data { get => playerData; }

    public override Data GetData()
    {
        return playerData;
    }

    public void SetData(PlayerData data)
    {
        playerData = data;
    }
}
