using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class SoldierData : Data
{
    [SerializeField]
    private int amount;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float movement;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private int maxActionsPerTurn;
    [SerializeField]
    private int actionsRemaining;

    [SerializeField]
    private PlayerType ownType;

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

    public float AttackRange
    {
        get => attackRange;
        set
        {
            attackRange = value;
            DataChanged.Invoke(this);
        }
    }

    public int ActionsRemaining
    {
        get => actionsRemaining;
        set
        {
            actionsRemaining = value;
            DataChanged.Invoke(this);
        }
    }

    public int MaxActionsPerTurn
    {
        get => maxActionsPerTurn;
    }

    public PlayerType Ownership
    {
        get => ownType;
        set
        {
            ownType = value;
            DataChanged.Invoke(this);
        }
    }
}
