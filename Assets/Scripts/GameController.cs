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
    private TurnController turnController;

    private GameObject currentSoldier;

    private ObservableCollection<SoldierMovement> soldiers = new ObservableCollection<SoldierMovement>();

    public GameObject CurrentSoldier { get => currentSoldier; }

    private void Awake()
    {
        var objs = turnController.Initialize();
        soldiers.CollectionChanged += UpdateSubscription;
        for (int i = 0; i < objs.Count; ++i)
        {
            soldiers.Add(objs[i].GetComponent<SoldierMovement>());
        }
    }

    private void OnDisable()
    {
        soldiers.CollectionChanged -= UpdateSubscription;
    }

    private void UpdateSubscription(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        for (int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].OnDeselected += Deselect;
            soldiers[i].OnSelected += Select;
        }
    }

    private void Deselect()
    {
        for (int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].SoldierSelector.Deselect();
        }
    }

    private void Select(GameObject obj)
    {
        currentSoldier = obj;
        rangeDrawer.DrawRange(obj.transform.position, obj.GetComponent<SoldierController>().Data.Movement);
    }

    private void Update()
    {
        if (currentSoldier)
            MoveObject();
    }

    private void MoveObject()
    {
        SoldierMovement solMov = currentSoldier.GetComponent<SoldierMovement>();
        if (Input.GetMouseButtonDown(0))
            MoveSoldier(solMov);
    }

    private void MoveSoldier(SoldierMovement solMov)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            var tile = hit.collider.GetComponent<HexTile>();
            if (tile && tile.Data.Status == Type.REACHABLE)
                solMov.MoveToTile(tile.transform.position, (tile.transform.position - solMov.transform.position).sqrMagnitude);
        }
    }
}
