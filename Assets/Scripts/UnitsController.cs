using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class UnitsController : MonoBehaviour
{
    [SerializeField]
    private TurnController turnController;

    private ObservableCollection<SoldierMovement> soldiers = new ObservableCollection<SoldierMovement>();
    public ObservableCollection<SoldierMovement> Soldiers { get => soldiers; }

    public void Initialize()
    {
        var objs = turnController.Initialize();
        for (int i = 0; i < objs.Count; ++i)
        {
            soldiers.Add(objs[i].GetComponent<SoldierMovement>());
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < Soldiers.Count; ++i)
        {
            Soldiers[i].GetComponent<SoldierCombatController>().OnDestroy += DestroyTroop;
        }

    }

    private void OnDisable()
    {
        for (int i = 0; i < Soldiers.Count; ++i)
        {
            Soldiers[i].GetComponent<SoldierCombatController>().OnDestroy -= DestroyTroop;
        }
    }

    public void DestroyTroop(GameObject go)
    {
        var obj = soldiers.Where(x => x.gameObject == go);
        for(int i = 0; i < obj.Count(); ++i)
        {
            soldiers.Remove(obj.ElementAt(i));
        }

        turnController.CurrentPlayer.Data.KilledEnemies++;

        Destroy(go);
    }
}
