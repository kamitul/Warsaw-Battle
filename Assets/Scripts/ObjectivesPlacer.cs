using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesPlacer : MapPlacer
{
    [SerializeField]
    private GameObject plObjectivePrefab = default;

    [SerializeField]
    private GameObject rusObjectivePrefab = default;

    public override List<GameObject> PlaceOnMap()
    {
        List<GameObject> env = new List<GameObject>();
        for (int i = 0; i < 3; ++i)
        {
            var tile = tiles[UnityEngine.Random.Range(0, tiles.Count - 1)];
            tile.GetComponent<HexTile>().Data.Status = Type.NON_WALKABLE;
            var obj = Instantiate(plObjectivePrefab, tile.transform.position, Quaternion.identity, null);
            env.Add(obj);
        }
        for (int i = 0; i < 3; ++i)
        {
            var tile = tiles[UnityEngine.Random.Range(0, tiles.Count - 1)];
            tile.GetComponent<HexTile>().Data.Status = Type.NON_WALKABLE;
            var obj = Instantiate(rusObjectivePrefab, tile.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), null);
            env.Add(obj);
        }
        return env;
    }
}
