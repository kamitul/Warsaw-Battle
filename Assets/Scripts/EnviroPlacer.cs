using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroPlacer : MapPlacer
{
    [SerializeField]
    private List<GameObject> enviroPrefabs = default;

    public override List<GameObject> PlaceOnMap()
    {
        List<GameObject> env = new List<GameObject>();
        for (int i = 0; i < 20; ++i)
        {
            var tile = tiles[UnityEngine.Random.Range(0, tiles.Count - 1)];
            tiles.Remove(tile);
            tile.GetComponent<HexTile>().Data.Status = Type.NON_WALKABLE;
            var obj = Instantiate(enviroPrefabs[UnityEngine.Random.Range(0, enviroPrefabs.Count - 1)], tile.transform.position, Quaternion.identity, null);
            env.Add(obj);
        }
        return env;
    }
}
