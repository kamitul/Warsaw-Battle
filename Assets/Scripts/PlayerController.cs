using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller, ITurnable, IInitiable
{
    [SerializeField]
    private PlayerData playerData;

    public PlayerData Data { get => playerData; }

    public void EndTurn(PlayerController pl)
    {
        Data.Coins += Data.KilledEnemies * 20;
        Data.KilledEnemies = 0;
    }

    public override Data GetData()
    {
        return playerData;
    }

    public void Initialize(PlayerController pl)
    {
        
    }

    public void SetData(PlayerData data)
    {
        playerData = data;
    }
}
