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

    public void EndTurn(PlayerController pl)
    {
        coins.text = pl.Data.Coins.ToString();
        soldiders.text = pl.Data.Soldiers.Count.ToString();
    }

    public void Initialize(PlayerController pl)
    {
        coins.text = pl.Data.Coins.ToString();
        soldiders.text = pl.Data.Soldiers.Count.ToString();
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
