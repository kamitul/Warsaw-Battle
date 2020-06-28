using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectiveController : TurnObject, ITurnable, IInitiable
{
    protected List<SoldierController> soldiers;
    public PlayerType Ownership;

    private void Awake()
    {
        soldiers = new List<SoldierController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var sol = other.GetComponent<SoldierController>();
        if (sol)
            soldiers.Add(sol);
    }

    private void OnTriggerExit(Collider other)
    {
        var sol = other.GetComponent<SoldierController>();
        if (sol)
            soldiers.Remove(sol);
    }

    public void EndTurn(PlayerController pl)
    {
        Dictionary<PlayerType, int> counts = new Dictionary<PlayerType, int>()
        {
            {PlayerType.PLAYER1, 0 },
            {PlayerType.PLAYER2, 0 }
        };

        for (int i = 0; i < soldiers.Count; ++i)
        {
            counts[soldiers[i].Data.Ownership]++;
        }

        var mostUnits = counts.OrderBy(x => x.Value).Last();

        if (mostUnits.Key == Ownership)
            DataController.Instance.GetController<PlayerController>(mostUnits.Key).Data.Coins += mostUnits.Value * 25;
        else
            DataController.Instance.GetController<PlayerController>(mostUnits.Key).Data.Coins += mostUnits.Value * 50;
    }

    public void Initialize(PlayerController pl)
    {

    }
}
