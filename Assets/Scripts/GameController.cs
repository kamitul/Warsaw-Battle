using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private RangeDrawer rangeDrawer;

    [SerializeField]
    private List<SoldierMovement> soldiers;

    private GameObject currentSoldier;

    public GameObject CurrentSoldier { get => currentSoldier; }

    private void OnEnable()
    {
        for(int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].OnDeselected += Deselect;
            soldiers[i].OnSelected += Select;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].OnDeselected -= Deselect;
            soldiers[i].OnSelected -= Select;
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
            if (tile)
                solMov.MoveToTile(tile.transform.position, (tile.transform.position - solMov.transform.position).sqrMagnitude);
        }
    }
}
