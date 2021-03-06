﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private RangeDrawer rangeDrawer;

    [SerializeField]
    private LightningController lightningController;

    [SerializeField]
    private TurnController turnController;

    [SerializeField]
    private UnitsController unitsController;

    [SerializeField]
    private LayerMask layer;

    private GameObject currentSoldier;

    public GameObject CurrentSoldier { get => currentSoldier; }
    public PlayerController CurrentPlayer { get => turnController.CurrentPlayer; }

    private void Awake()
    {
        unitsController.Soldiers.CollectionChanged += UpdateSubscription;
        unitsController.Initialize();
    }

    private void OnDisable()
    {
        unitsController.Soldiers.CollectionChanged -= UpdateSubscription;
    }

    private void UpdateSubscription(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        for (int i = 0; i < unitsController.Soldiers.Count; ++i)
        {
            unitsController.Soldiers[i].OnDeselected += Deselect;
            unitsController.Soldiers[i].OnSelected += Select;
        }
    }

    private void Deselect()
    {
        for (int i = 0; i < unitsController.Soldiers.Count; ++i)
        {
            unitsController.Soldiers[i].SoldierSelector.Deselect();
        }
    }

    private void Select(GameObject obj)
    {
        if (obj.GetComponent<SoldierController>().Data.Ownership == CurrentPlayer.Data.PlayerType)
        {
            currentSoldier = obj;
            rangeDrawer.DrawRange(obj.transform.position, obj.GetComponent<SoldierController>().Data.Movement / 1.5f);
            lightningController.SetLightning(obj);
        }
    }

    private void Update()
    {
        if (currentSoldier)
        {
            PerformAction();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSoldier = null;
            rangeDrawer.Redraw();
            turnController.NextTurn();
        }
    }

    public void EndTurn()
    {
        currentSoldier = null;
        rangeDrawer.Redraw();
        turnController.NextTurn();
    }

    private void PerformAction()
    {
        if (Input.GetMouseButtonDown(0))
            PerformSoldierAction();
    }

    private void PerformSoldierAction()
    {
        if (currentSoldier.GetComponent<SoldierController>().Data.ActionsRemaining <= 0)
        {
            Debug.Log("No actions remaining for this unit");
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f, layer))
        {
            var tile = hit.collider.GetComponent<HexTile>();

            if (tile && tile.Data.Status == Type.REACHABLE)
            {
                SoldierMovement sol = currentSoldier.GetComponent<SoldierMovement>();
                sol.MoveToTile(tile.transform.position, (tile.transform.position - sol.transform.position).sqrMagnitude);
                tile.Data.Status = Type.UNIT;
                ResetMovement();
                currentSoldier.GetComponent<SoldierController>().Data.ActionsRemaining--;
                currentSoldier = null;
                rangeDrawer.Redraw();

            }
            else if (tile && tile.Data.Status == Type.UNIT)
            {
                SoldierController clickedSoldier = tile.Data.CurrentObj.GetComponent<SoldierController>();

                if (clickedSoldier && clickedSoldier.Data.Ownership != CurrentPlayer.Data.PlayerType)
                {
                    bool rangeResult = GaugeAttackRange(currentSoldier, tile.Data.CurrentObj);
                    if (rangeResult)
                    {
                        PerformAttack(currentSoldier, tile.Data.CurrentObj);
                        currentSoldier.GetComponent<SoldierController>().Data.ActionsRemaining--;
                    }
                }
            }
        }
    }

    private bool GaugeAttackRange(GameObject currentSoldier, GameObject clickedSoldier)
    {
        SoldierController currentCtrl = currentSoldier.GetComponent<SoldierController>();
        return currentCtrl.Data.AttackRange * HexTile.HexSize >= Vector3.Distance(currentSoldier.transform.position, clickedSoldier.transform.position);
    }

    private void PerformAttack(GameObject currentSoldier, GameObject clickedSoldier)
    {
        clickedSoldier.GetComponent<SoldierCombatController>().TakeDamage(currentSoldier.GetComponent<SoldierCombatController>().DamageDealt);
    }

    private void ResetMovement()
    {
        for (int i = 0; i < unitsController.Soldiers.Count; ++i)
        {
            var sol = unitsController.Soldiers[i].GetComponent<SoldierController>();
            if (sol.Data.Ownership == CurrentPlayer.Data.PlayerType)
                sol.Data.Movement = 0;
        }
    }
}
