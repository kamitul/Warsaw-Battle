using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFactory
{
    private MapPlacer mapPlacer;

    public void Set(MapPlacer mapPlacer)
    {
        this.mapPlacer = mapPlacer;
    }

    public void Generate()
    {
        this.mapPlacer.PlaceOnMap();
    }
}
