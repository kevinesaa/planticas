using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadquarterController : MonoBehaviour, IHealthManager
{
    public event Action<int,int> OnHealthChange;
    public event Action<int> OnHealtZero;
    
    public int maxHealth;

    private int health;
    private int playerId;

    private void Awake()
    {
        health = maxHealth;
    }

    

    public int GetPlayerId()
    {
        return playerId;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void ModifyHealt(int modifier)
    {
        health += modifier;
        if (OnHealthChange != null)
            OnHealthChange(playerId,modifier);
        if (health <= 0)
        {
            if (OnHealtZero != null)
                OnHealtZero(playerId);
        }
        else
        {
            if (health > maxHealth)
                health = maxHealth;
        }
    }

    internal void SetPlayerId(int playerId)
    {
        this.playerId = playerId;
    }

}
