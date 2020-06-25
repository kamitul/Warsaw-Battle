using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mouse", menuName = "ScriptableObjects/MouseData", order = 1)]
public class MouseData : ScriptableObject
{
    public float MouseSensX = 7f;
    public float MouseSensY = 7f;
    public float MouseSensZ = 5f;
}
