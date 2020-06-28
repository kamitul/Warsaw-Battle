using System;
using UnityEngine;

public class SoldierCombatController : MonoBehaviour
{
    [SerializeField] private SoldierController soldierController;

    public Action<int> OnDamageTaken;

    public float DamageDealt
    {
        get => soldierController.Data.Amount * soldierController.Data.Damage;
    }

    public void takeDamage(float damageAmount)
    {
        int unitsDiedCount = (int)(damageAmount / soldierController.Data.HP);
        soldierController.Data.Amount -= unitsDiedCount;

        if (soldierController.Data.Amount <= 0)
        {
            executeDeath();
        }

        OnDamageTaken?.Invoke(unitsDiedCount);
    }

    private void executeDeath()
    {
        Debug.Log("Death of " + gameObject);
        // ?
    }
}