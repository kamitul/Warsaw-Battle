using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : TurnObject, ITurnable, IInitiable
{
    [SerializeField]
    private List<GameObject> screens;

    [SerializeField]
    private TextMeshProUGUI coins;

    [SerializeField]
    private TextMeshProUGUI soldiders;

    [SerializeField]
    private List<PlayerController> players;

    private void OnEnable()
    {
        for(int i = 0; i <players.Count; ++i)
        {
            players[i].Data.DataChanged += UpdateUI;
        }
    }

    private void UpdateUI(PlayerData obj)
    {
        coins.text = obj.Coins.ToString();
        int counter = 0;
        for (int i = 0; i < obj.Soldiers.Count; ++i)
        {
            counter += obj.Soldiers[i].GetComponent<SoldierController>().Data.Amount;
        }
        soldiders.text = counter.ToString();
    }

    private void OnDisable()
    {
        for (int i = 0; i < players.Count; ++i)
        {
            players[i].Data.DataChanged -= UpdateUI;
        }
    }

    public void EndTurn(PlayerController pl)
    {
        UpdateUI(pl.Data);
    }

    public void Initialize(PlayerController pl)
    {
        UpdateUI(pl.Data);
    }

    public void OpenScreen(string name)
    {
        for (int i = 0; i < screens.Count; ++i)
        {
            screens[i].SetActive(false);
        }
        GameObject screen = screens.Find(x => x.name == name);
        screen.SetActive(true);
    }

    public void DisableScreen(string name)
    {
        GameObject screen = screens.Find(x => x.name == name);
        screen.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
