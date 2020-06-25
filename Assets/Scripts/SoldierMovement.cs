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

    public Action OnDeselected;
    public Action<GameObject> OnSelected;

    public SoldierSelector SoldierSelector { get => soldierSelector; }

    private void OnMouseDown()
    {
        OnDeselected.Invoke();
        SoldierSelector.Select();
        OnSelected.Invoke(gameObject);
    }

    public void MoveToTile(Vector3 pos, float time)
    {
        transform.DOMove(pos, time);
    }
}
