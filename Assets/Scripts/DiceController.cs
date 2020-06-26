using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class DiceController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    public Dictionary<Transform, int> DicePoints;

    [SerializeField]
    private List<Transform> edges;

    public int Points;
    public bool Rolled = false;

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

    private void OnMouseDown()
    {
        RollDice();
        Rolled = true;
    }

    private void RollDice()
    {
        rg.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        rg.AddTorque(new Vector3(UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500)));
    }
}
