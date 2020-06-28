using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public EnemyType EnemyType;
    public GameObject Obj;
}

public class UnitsController : MonoBehaviour
{
    [SerializeField]
    private TurnController turnController;

    [SerializeField]
    private MapGenerator mapGenerator;

    [SerializeField]
    private List<UnitData> unitDatas;


    private ObservableCollection<SoldierMovement> soldiers = new ObservableCollection<SoldierMovement>();
    public ObservableCollection<SoldierMovement> Soldiers { get => soldiers; }

    public void Initialize()
    {
        var objs = turnController.Initialize();
        for (int i = 0; i < objs.Count; ++i)
        {
            soldiers.Add(objs[i].GetComponent<SoldierMovement>());
        }
        soldiers.CollectionChanged += SubscribeEvents;
    }

    private void SubscribeEvents(object sender, NotifyCollectionChangedEventArgs e)
    {
        for (int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].GetComponent<SoldierCombatController>().OnDestroy += DestroyTroop;
        }

    }

    private void OnDisable()
    {
        for (int i = 0; i < soldiers.Count; ++i)
        {
            soldiers[i].GetComponent<SoldierCombatController>().OnDestroy -= DestroyTroop;
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

    public void SpawnTroop(GameObject type)
    {
        UITroop troopType = type.GetComponent<UITroop>();
        if (turnController.CurrentPlayer.Data.Coins >= troopType.Price)
        {
            var obj = unitDatas.Find(x => x.EnemyType == troopType.Type);
            var inst = Instantiate(obj.Obj, null);
            soldiers.Add(inst.GetComponent<SoldierMovement>());
            turnController.CurrentPlayer.Data.Soldiers.Add(inst);
            turnController.CurrentPlayer.Data.Coins -= troopType.Price;
            mapGenerator.PlaceTroopBase(inst, turnController.CurrentPlayer, Quaternion.identity);
        }
    }
}
