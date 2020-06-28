using System;
using UnityEngine;

public class SoldierCombatController : MonoBehaviour
{
    [SerializeField] private SoldierController soldierController;

    public Action OnDamageTaken;

    public float DamageDealt
    {
        get => soldierController.Data.Amount * soldierController.Data.Damage;
    }

    public void takeDamage(float damageAmount)
    {
        soldierController.Data.Amount -= (int)(damageAmount / soldierController.Data.HP);

        if (soldierController.Data.Amount <= 0)
        {
            executeDeath();
        }

        OnDamageTaken?.Invoke();
    }

    private void executeDeath()
    {
        Debug.Log("Death of " + gameObject);
        // ?
    }
}