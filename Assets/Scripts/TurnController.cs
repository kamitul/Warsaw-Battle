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

public class TurnController : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private MapGenerator mapGenerator;

    [SerializeField]
    private TurnBinder turnBinder;

    [SerializeField]
    private PlayerController player1;

    [SerializeField]
    private PlayerController player2;

    [SerializeField]
    private List<Troop> initialTroops;

    [SerializeField]
    private List<Place> dicePlaces;

    [SerializeField]
    private DiceController dice;

    [HideInInspector]
    public PlayerController CurrentPlayer;

    public Dictionary<PlayerType, PlayerController> Players = new Dictionary<PlayerType, PlayerController>();

    [SerializeField]
    private List<TurnObject> turnables;

    private void Awake()
    {
        for(int i = 0; i < mapGenerator.Objectives.Count; ++i)
        {
            turnables = turnables.Prepend(mapGenerator.Objectives[i].GetComponent<TurnObject>()).ToList();
        }
        turnBinder.Bind();
    }

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
            var troop = initialTroops[i].Positions.Find(x => x.Ownership == pl);
            if (troop != null)
            {
                Vector3 position = troop.Position;
                var obj = Instantiate(initialTroops[i].Soldier, position, Quaternion.identity, null);
                ret.Add(obj);
            }
        }
        return ret;
    }

    public void NextTurn()
    {
        if (CurrentPlayer)
        {
            CurrentPlayer = CurrentPlayer == player1 ? player2 : player1;
            cameraController.MoveToPoint(CurrentPlayer.Data.PlayerType);
            dice.Data.Rolled = false;
            dice.transform.position = dicePlaces.Find(x => x.Ownership == CurrentPlayer.Data.PlayerType).Position;
            ProcessTurnables();
        }
    }

    private void ProcessTurnables()
    {
        for(int i = 0; i < turnables.Count; ++i)
        {
            (turnables[i] as ITurnable).EndTurn();
        }
    }

    public void OnBeforeSerialize()
    {
        Players.Clear();
        Players.Add(player1.Data.PlayerType, player1);
        Players.Add(player2.Data.PlayerType, player2);
    }

    public void OnAfterDeserialize()
    {
        
    }
}
