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
            if (tiles[i].GetComponent<HexTile>().Data.Status != Type.NON_WALKABLE)
            {
                tiles[i].GetComponent<MeshRenderer>().material.SetColor("_Color", selectedColor);
                tiles[i].GetComponent<HexTile>().Data.Status = Type.REACHABLE;
            }
        }
    }

    private void RedrawTiles()
    {
        for (int i = 0; i < mapGenerator.HexTiles.Count; ++i)
        {
            if (mapGenerator.HexTiles[i].GetComponent<HexTile>().Data.Status != Type.NON_WALKABLE)
            {
                mapGenerator.HexTiles[i].GetComponent<MeshRenderer>().material.SetColor("_Color", defaultColor);
                mapGenerator.HexTiles[i].GetComponent<HexTile>().Data.Status = Type.NON_REACHABLE;
            }
        }
    }

    private GameObject[] SelectTiles(Vector3 position, float range)
    {
        List<GameObject> tiles = mapGenerator.HexTiles.FindAll(x => (x.transform.position - position).sqrMagnitude < range);
        return tiles.ToArray();
    }

    public void Redraw()
    {
        RedrawTiles();
    }
}
