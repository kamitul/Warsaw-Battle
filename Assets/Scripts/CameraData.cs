using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerType
{
    PLAYER1,
    PLAYER2,
    NOTHING
}


[System.Serializable]
public class CameraData : Data
{
    public Vector3 Position;
    public Vector3 Rotation;
    public float Speed;
    public PlayerType Type;
}
