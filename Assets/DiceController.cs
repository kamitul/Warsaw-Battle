using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class DiceController : MonoBehaviour
{
    public Dictionary<Transform, int> DicePoints;

    [SerializeField]
    private List<Transform> edges;

    public int Points;

    private void Awake()
    {
        DicePoints = new Dictionary<Transform, int>()
        {
            {edges[0], 1},
            {edges[1], 2},
            {edges[2], 3},
            {edges[3], 4},
            {edges[4], 5},
            {edges[5], 6},
        };
    }

    private void Update()
    {
        Points = DicePoints.OrderBy(x => (x.Key.forward - Vector3.up).sqrMagnitude).First().Value;
    }
}
