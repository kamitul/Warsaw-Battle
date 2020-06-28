using System;
using UnityEngine;

public class SoldierCombatController : MonoBehaviour
{
    [SerializeField] private SoldierController soldierController;

    public Action<int> OnDamageTaken;
    public Action<GameObject> OnDestroy;

    public float DamageDealt
    {
        get => soldierController.Data.Amount * soldierController.Data.Damage;
    }

    public void TakeDamage(float damageAmount)
    {
        int unitsDiedCount = (int)(damageAmount / soldierController.Data.HP);
        soldierController.Data.Amount -= unitsDiedCount;

        if (soldierController.Data.Amount <= 0)
        {
            ExecuteDeath();
        }

        OnDamageTaken?.Invoke(unitsDiedCount);
    }

    private void ExecuteDeath()
    {
        OnDestroy?.Invoke(gameObject);
    }
}