using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField]
    private SoldierSelector soldierSelector;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private TroopSoundPlayer troopSoundPlayer;

    public Action OnDeselected;
    public Action<GameObject> OnSelected;

    public SoldierSelector SoldierSelector { get => soldierSelector; }

    private void Awake()
    {
        troopSoundPlayer = GetComponent<TroopSoundPlayer>();
    }

    private void OnMouseDown()
    {
        troopSoundPlayer.Click();
        OnDeselected.Invoke();
        SoldierSelector.Select();
        OnSelected.Invoke(gameObject);
    }

    public void MoveToTile(Vector3 pos, float time)
    {
        troopSoundPlayer.Move();
        pos.y = transform.position.y;
        transform.DOMove(pos, time);
    }
}
