using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSelector : MonoBehaviour
{
    [SerializeField]
    private Renderer skinnedMesh;

    public float OutlineStrength = 0.5f;
    public bool IsSelected = false;

    public void Select()
    {
        var color = skinnedMesh.materials[skinnedMesh.materials.Length - 1].GetColor("_OutlineColor");
        skinnedMesh.materials[skinnedMesh.materials.Length - 1].SetColor("_OutlineColor", new Color(color.r, color.g, color.b, OutlineStrength));
        IsSelected = true;
    }

    public void Deselect()
    {
        var color = skinnedMesh.materials[skinnedMesh.materials.Length - 1].GetColor("_OutlineColor");
        skinnedMesh.materials[skinnedMesh.materials.Length - 1].SetColor("_OutlineColor", new Color(color.r, color.g, color.b, 0f));
        IsSelected = false;
    }
}
