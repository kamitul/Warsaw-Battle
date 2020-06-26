using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : Controller
{
    [SerializeField]
    private SoldierData data;

    [SerializeField]
    private SoldierUIController soldierUI;

    public SoldierData Data { get => data; }

    public override Data GetData()
    {
        return data;
    }

    private void Awake()
    {
        soldierUI.Set(Data as SoldierData);
    }
}
