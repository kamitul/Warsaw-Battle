using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Place
{
    public Vector3 Position;
    public PlayerType Ownership;
}

[System.Serializable]
public class Troop
{
    public GameObject Soldier;
    public List<Place> Positions;
}

public class TurnController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private PlayerController player1;

    [SerializeField]
    private PlayerController player2;

    [SerializeField]
    private List<Troop> initialTroops;

    [SerializeField]
    private DiceController dice;

    public PlayerController CurrentPlayer;

    public List<GameObject> Initialize()
    {
        var player1Troops = SpawnStartTroops(PlayerType.PLAYER1);
        player1.SetData(new PlayerData(0, player1Troops, 0, PlayerType.PLAYER1));
        var player2Troops = SpawnStartTroops(PlayerType.PLAYER2);
        player2.SetData(new PlayerData(0, player2Troops, 0, PlayerType.PLAYER2));
        CurrentPlayer = player1;
        player2Troops.ForEach(x => player1Troops.Add(x));
        return player1Troops;
    }

    private List<GameObject> SpawnStartTroops(PlayerType pl)
    {
        List<GameObject> ret = new List<GameObject>();
        for(int i = 0; i < initialTroops.Count; ++i)
        {
            Vector3 position = initialTroops[i].Positions.Find(x => x.Ownership == pl).Position;
            var obj = Instantiate(initialTroops[i].Soldier, position, Quaternion.identity, null);
            ret.Add(obj);
        }
        return ret;
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
            dice.Rolled = false;
        }
    }
}
