using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoldierUIController : MonoBehaviour, ISetable
{
    [SerializeField]
    private TextMeshProUGUI amount;
    [SerializeField]
    private GameObject damageTooltip;

    private SoldierData soldierData;

    private void OnDisable()
    {
        soldierData.DataChanged -= UpdateUI;
        gameObject.GetComponent<SoldierCombatController>().OnDamageTaken -= displayDmgTaken;
    }

    public void Set(dynamic data)
    {
        this.soldierData = data as SoldierData;
        soldierData.DataChanged += UpdateUI;
        gameObject.GetComponent<SoldierCombatController>().OnDamageTaken += displayDmgTaken;
    }

    private void UpdateUI(SoldierData obj)
    {
        amount.text = obj.Amount.ToString();
    }

    private void displayDmgTaken(int dmg)
    {
        damageTooltip.SetActive(true);
        damageTooltip.GetComponentInChildren<Text>().text = "-" + dmg.ToString();

        Tween dmgMove = damageTooltip.transform.DOLocalMoveY(500, 1).OnComplete(() =>
        {
            damageTooltip.SetActive(false);
            damageTooltip.transform.localPosition = Vector3.zero;
        });

        dmgMove.Play();
    }

}
