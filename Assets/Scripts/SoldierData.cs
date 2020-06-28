using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum EnemyType
{
    RUS1,
    POL1,
    RUS2,
    POL2,
    RUS3,
    POL3,
    ARM_RUS,
    ARM_POL
}


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
    [SerializeField]
    private EnemyType enemyType;

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

    public EnemyType Type
    {
        get => enemyType;
        set
        {
            enemyType = value;
        }
    }
}
