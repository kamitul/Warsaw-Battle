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
}
