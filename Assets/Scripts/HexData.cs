using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    REACHABLE,
    NON_REACHABLE,
    NON_WALKABLE,
    WALKABLE,
    UNIT
}

[System.Serializable]
public class HexData : Data
{
    public Type Status;
    public GameObject CurrentObj;
}
