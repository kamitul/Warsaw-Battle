using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private PlayerController player1;

    [SerializeField]
    private PlayerController player2;

    [SerializeField]
    private List<GameObject> startTroops;

    public PlayerController CurrentPlayer;

    private void Awake()
    {
        player1.SetData(new PlayerData(0, startTroops, 0, Position.PLAYER1));
        player2.SetData(new PlayerData(0, startTroops, 0, Position.PLAYER2));
        CurrentPlayer = player1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            NextTurn();
    }

    private void NextTurn()
    {
        if (CurrentPlayer)
        {
            CurrentPlayer = CurrentPlayer == player1 ? player2 : player1;
            cameraController.MoveToPoint(CurrentPlayer.Data.PlayerType);
        }
    }
}
