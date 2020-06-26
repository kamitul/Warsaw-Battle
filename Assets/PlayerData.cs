using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private List<GameObject> soldiers;

    [SerializeField]
    private int coins;

    [SerializeField]
    private Position playerType;

    public Action<PlayerData> DataChanged;

    public PlayerData(int timer, List<GameObject> startTroops, int coins, Position type)
    {
        this.timer = timer;
        this.soldiers = startTroops;
        this.coins = coins;
        this.playerType = type;
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

    public Position PlayerType
    {
        get => playerType;
        set
        {
            playerType = value;
            DataChanged?.Invoke(this);
        }
    }
}
