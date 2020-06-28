using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitActionCountController : TurnObject, ITurnable, IInitiable
{
    public void EndTurn(PlayerController pl)
    {
        foreach (var soldier in pl.Data.Soldiers)
        {
            SoldierController ctrl = soldier.GetComponent<SoldierController>();
            ctrl.Data.ActionsRemaining = ctrl.Data.MaxActionsPerTurn;
        }
    }

    public void Initialize(PlayerController pl)
    {

    }
}