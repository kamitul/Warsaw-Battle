using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCollider : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer meshRenderer;

    [SerializeField]
    private MeshCollider meshCollider;

    private Mesh mesh;

    private void Awake()
    {
        mesh = new Mesh();
    }

    private void Update()
    {
        meshRenderer.BakeMesh(mesh);
        meshCollider.sharedMesh = mesh;
    }
}
