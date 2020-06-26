﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    REACHABLE,
    NON_REACHABLE,
    NON_WALKABLE,
}

[System.Serializable]
public class HexData 
{
    public Type Status;
}
