using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : Controller
{
    [SerializeField]
    private HexData hexData;

    public HexData Data { get => hexData; }

    public override Data GetData()
    {
        return hexData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Data.CurrentObj)
            Data.CurrentObj = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        Data.CurrentObj = null;
    }
}
