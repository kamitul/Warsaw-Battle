﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class SoldierData
{
    [SerializeField]
    private int amount;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float movement;

    [HideInInspector]
    public float TotalDamage;

    public Action<SoldierData> DataChanged;

    public int Amount 
    { 
        get => amount;
        set 
        { 
            amount = value;
            DataChanged.Invoke(this);
        } 
    }

    public float Damage
    {
        get => damage;
        set
        {
            damage = value;
            DataChanged.Invoke(this);
        }
    }

    public float HP
    {
        get => hp;
        set
        {
            hp = value;
            DataChanged.Invoke(this);
        }
    }

    public float Movement
    {
        get => movement;
        set
        {
            movement = value;
            DataChanged.Invoke(this);
        }
    }
}