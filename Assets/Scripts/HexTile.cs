using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexTile : Controller
{
    [SerializeField]
    private HexData hexData;

    [SerializeField]
    private MeshRenderer mesh;

    public static float HexSize = 0.5f;

    private Color prevColor;

    public HexData Data { get => hexData; }

    public override Data GetData()
    {
        return hexData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Data.CurrentObj)
            Data.CurrentObj = other.gameObject;

        if (Data.CurrentObj.GetComponent<SoldierController>())
        {
            Data.Status = Type.UNIT;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Data.CurrentObj = null;
        Data.Status = Type.WALKABLE;
    }

    private void OnMouseEnter()
    {
        prevColor = mesh.materials[mesh.materials.Length - 1].color;
        mesh.materials[mesh.materials.Length - 1].color = Color.green;
    }

    private void OnMouseExit()
    {
        mesh.materials[mesh.materials.Length - 1].color = prevColor;
    }
}
