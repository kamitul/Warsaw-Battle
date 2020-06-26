using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    [SerializeField]
    private List<Controller> dataHolders;

    private List<Data> datas = new List<Data>();
    private Dictionary<PlayerType, Data> playersData = new Dictionary<PlayerType, Data>();

    protected override void Awake()
    {
        base.Awake();
        SerializeData();
    }

    public T GetData<T>() 
        where T : Data
    {
        var data = datas.Select(x => x as T);
        return data as T;
    }

    public T GetController<T>(PlayerType type)
        where T : Controller
    {
        var controller = dataHolders.FindAll(x => x as T);
        var contr = controller.Find(x => (x as PlayerController).Data.PlayerType == type);
        return contr as T;
    }

    public T GetController<T>()
        where T : Controller
    {
        var controller = dataHolders.Find(x => x as T);
        return controller as T;
    }

    public PlayerData GetPlayerData(PlayerType type)
    {
        return playersData[type] as PlayerData;
    }

    private void SerializeData()
    {
        datas.Clear();
        playersData.Clear();
        for (int i = 0; i < dataHolders.Count; ++i)
        {
            PlayerController pl = dataHolders[i] as PlayerController;
            if (pl)
                playersData.Add(pl.Data.PlayerType, pl.Data);
            else
                datas.Add(dataHolders[i].GetComponent<Controller>().GetData());
        }
    }
}
