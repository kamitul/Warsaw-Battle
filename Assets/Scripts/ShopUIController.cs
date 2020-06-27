using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerUI
{
    public PlayerType Type;
    public Sprite Icon;
}

public class ShopUIController : TurnObject, ITurnable, IInitiable
{
    [SerializeField]
    private List<Image> troops;

    [SerializeField]
    private List<PlayerUI> playerUIs;

    public void EndTurn(PlayerController pl)
    {
        var currPlayer = playerUIs.FindAll(x => x.Type == pl.Data.PlayerType);
        for(int i = 0; i < troops.Count; ++i)
        {
            troops[i].sprite = currPlayer[i].Icon;
        }
    }

    public void Initialize(PlayerController pl)
    {
        var currPlayer = playerUIs.FindAll(x => x.Type == pl.Data.PlayerType);
        for (int i = 0; i < troops.Count; ++i)
        {
            troops[i].sprite = currPlayer[i].Icon;
        }
    }
}
