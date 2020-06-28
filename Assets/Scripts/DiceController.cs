using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class DiceController : Controller
{
    [SerializeField]
    private DiceData diceData;

    [SerializeField]
    private Rigidbody rg;

    public Dictionary<Transform, int> DicePoints;

    [SerializeField]
    private List<Transform> edges;

    public DiceData Data { get => diceData; }

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
        Data.Tick(DicePoints.OrderBy(x => (x.Key.forward - Vector3.up).sqrMagnitude).First().Value);
    }

    private void OnMouseDown()
    {
        if (!Data.Rolled)
        {
            RollDice();
            Data.Rolled = true;
        }
    }

    private void RollDice()
    {
        rg.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        rg.AddTorque(new Vector3(UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500)));
    }

    public override Data GetData()
    {
        return diceData;
    }
}
