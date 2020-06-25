using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [SerializeField]
    private SoldierData data;

    [SerializeField]
    private SoldierUIController soldierUI;

    public SoldierData Data { get => data; }

    private void Awake()
    {
        soldierUI.Set(Data as SoldierData);
    }
}
