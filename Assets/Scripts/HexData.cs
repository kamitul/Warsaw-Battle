using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    WALKABLE,
    NON_WALKABLE,
}

[System.Serializable]
public class HexData 
{
    public Type Status;
}
