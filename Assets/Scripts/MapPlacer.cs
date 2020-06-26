using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapPlacer : MonoBehaviour
{
    protected List<GameObject> tiles;
    public void SetTiles(List<GameObject> tiles)
    {
        this.tiles = tiles;
    }
    public abstract List<GameObject> PlaceOnMap();
}
