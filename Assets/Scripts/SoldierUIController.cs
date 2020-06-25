using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierUIController : MonoBehaviour, ISetable
{
    [SerializeField]
    private TextMeshProUGUI amount;

    private SoldierData soldierData;

    private void OnDisable()
    {
        soldierData.DataChanged -= UpdateUI;
    }

    public void Set(dynamic data)
    {
        this.soldierData = data as SoldierData;
        soldierData.DataChanged += UpdateUI;
    }

    private void UpdateUI(SoldierData obj)
    {
        amount.text = obj.Amount.ToString();
    }

}
