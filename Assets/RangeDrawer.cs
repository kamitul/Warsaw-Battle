using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.Tilemaps;

public class RangeDrawer : MonoBehaviour
{
    [SerializeField]
    private MapGenerator mapGenerator;

    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    private Color selectedColor;

    public void DrawRange(Vector3 position, float range)
    {
        RedrawTiles();
        GameObject[] tiles = SelectTiles(position, range);
        for(int i = 0; i < tiles.Length; ++i)
        {
            tiles[i].GetComponent<MeshRenderer>().material.SetColor("_Color", selectedColor);
        }
    }

    private void RedrawTiles()
    {
        for (int i = 0; i < mapGenerator.HexTiles.Count; ++i)
        {
            mapGenerator.HexTiles[i].GetComponent<MeshRenderer>().material.SetColor("_Color", defaultColor);
        }
    }

    private GameObject[] SelectTiles(Vector3 position, float range)
    {
        List<GameObject> tiles = mapGenerator.HexTiles.FindAll(x => (x.transform.position - position).sqrMagnitude < range);
        return tiles.ToArray();
    }
}
