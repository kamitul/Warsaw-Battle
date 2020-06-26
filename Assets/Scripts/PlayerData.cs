using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData : Data
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private List<GameObject> soldiers;

    [SerializeField]
    private int coins;

    [SerializeField]
    private PlayerType playerType;

    public Action<PlayerData> DataChanged;

    public PlayerData(int timer, List<GameObject> startTroops, int coins, PlayerType type)
    {
        this.timer = timer;
        this.soldiers = startTroops;
        this.coins = coins;
        this.playerType = type;
        SetTroops();
    }

    private void SetTroops()
    {
        for(int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].GetComponent<SoldierController>().Data.Ownership = playerType;
        }
    }

    public int Coins
    {
        get => coins;
        set
        {
            coins = value;
            DataChanged?.Invoke(this);
        }
    }

    public float Timer
    {
        get => timer;
        set
        {
            timer = value;
            DataChanged?.Invoke(this);
        }
    }

    public List<GameObject> Soldiers
    {
        get => soldiers;
        set
        {
            soldiers = value;
            DataChanged?.Invoke(this);
        }
    }

    public PlayerType PlayerType
    {
        get => playerType;
        set
        {
            playerType = value;
            DataChanged?.Invoke(this);
        }
    }
}
