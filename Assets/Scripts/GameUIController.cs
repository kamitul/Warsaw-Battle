using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : TurnObject, ITurnable
{
    [SerializeField]
    private TextMeshProUGUI coins;

    [SerializeField]
    private TextMeshProUGUI soldiders;

    [SerializeField]
    private GameController gameController;

    private Dictionary<PlayerType, PlayerController> playerUIData;

    public void Bind()
    {
        playerUIData = new Dictionary<PlayerType, PlayerController>();
        playerUIData.Add(PlayerType.PLAYER1, DataController.Instance.GetController<PlayerController>(PlayerType.PLAYER1));
        playerUIData.Add(PlayerType.PLAYER2, DataController.Instance.GetController<PlayerController>(PlayerType.PLAYER2));
    }

    public void EndTurn()
    {
        coins.text = playerUIData[gameController.CurrentPlayer.Data.PlayerType].Data.Coins.ToString();
        soldiders.text = playerUIData[gameController.CurrentPlayer.Data.PlayerType].Data.Soldiers.Count.ToString();
    }
}
