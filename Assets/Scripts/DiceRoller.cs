using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private UnitsController unitsController;

    [SerializeField]
    private DiceController diceController;

    private void OnEnable()
    {
        diceController.Data.DataChanged += UpdateMovement;
    }

    private void OnDisable()
    {
        diceController.Data.DataChanged -= UpdateMovement;
    }

    private void UpdateMovement(DiceData obj)
    {
        for (int i = 0; i < unitsController.Soldiers.Count; ++i)
        {
            var sol = unitsController.Soldiers[i].GetComponent<SoldierController>();
            if (sol.Data.Ownership == gameController.CurrentPlayer.Data.PlayerType)
                sol.Data.Movement = obj.Points;
        }      
    }
}
