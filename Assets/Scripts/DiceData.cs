using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceData
{
    [SerializeField]
    private int points;
    [SerializeField]
    private bool rolled;

    public Action<DiceData> DataChanged;

    public int Points
    {
        get => points;
        set
        {
            points = value;
            DataChanged.Invoke(this);
        }
    }

    public bool Rolled
    {
        get => rolled;
        set
        {
            rolled = value;
            DataChanged.Invoke(this);
        }
    }

    public void Tick(int value)
    {
        if (value == Points)
            return;
        else
            Points = value;
    }
}
