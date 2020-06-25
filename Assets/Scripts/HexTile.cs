using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    [SerializeField]
    private HexData hexData;

    public HexData Data { get => hexData; }
}
