using System;
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
    private LayerMask layer;

    private GameObject currentSoldier;

    private ObservableCollection<SoldierMovement> soldiers = new ObservableCollection<SoldierMovement>();

    public GameObject CurrentSoldier { get => currentSoldier; }
    public PlayerController CurrentPlayer { get => turnController.CurrentPlayer; }
    public ObservableCollection<SoldierMovement> Soldiers { get => soldiers; }

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
                Debug.Log("move");
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
                        PerformAttack(currentSoldier.GetComponent<SoldierController>(), clickedSoldier);
                        currentSoldier.GetComponent<SoldierController>().Data.ActionsRemaining--;
                    }
                }
            }
        }
    }

    private bool GaugeAttackRange(GameObject currentSoldier, GameObject clickedSoldier)
    {
        SoldierController currentCtrl = currentSoldier.GetComponent<SoldierController>();

        Debug.Log(currentCtrl.Data.AttackRange * HexTile.HexSize + " " + Vector3.Distance(currentSoldier.transform.position, clickedSoldier.transform.position));

        return currentCtrl.Data.AttackRange * HexTile.HexSize >= Vector3.Distance(currentSoldier.transform.position, clickedSoldier.transform.position);
    }

    private void PerformAttack(SoldierController currentSoldier, SoldierController clickedSoldier)
    {
        clickedSoldier.Data.HP -= currentSoldier.Data.Damage;
        Debug.Log(clickedSoldier.Data.HP);
    }

    private void ResetMovement()
    {
        for (int i = 0; i < soldiers.Count; ++i)
        {
            var sol = soldiers[i].GetComponent<SoldierController>();
            if (sol.Data.Ownership == CurrentPlayer.Data.PlayerType)
                sol.Data.Movement = 0;
        }
    }
}
