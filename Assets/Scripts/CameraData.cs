using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Position
{
    PLAYER1,
    PLAYER2,
    BACK
}


[System.Serializable]
public class CameraData
{
    public Vector3 Position;
    public Vector3 Rotation;
    public float Speed;
    public Position Type;
}
