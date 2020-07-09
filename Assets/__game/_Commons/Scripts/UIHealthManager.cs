using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthManager : MonoBehaviour
{
    
    private IHealthManager healthManager;

    public Slider sliderHealth;
    

    public void SetHealthManager(IHealthManager healthManager)
    {
        if (this.healthManager!=null)
        {
            this.healthManager.OnHealthChange -= OnHealthChange;
            this.healthManager.OnHealtZero -= OnHealthZero;
        }
        this.healthManager = healthManager;

        this.healthManager.OnHealthChange += OnHealthChange;
        this.healthManager.OnHealtZero += OnHealthZero;

        sliderHealth.minValue = 0;
        sliderHealth.maxValue = this.healthManager.GetMaxHealth();
        sliderHealth.value = this.healthManager.GetHealth();
    }

    private void OnHealthChange(int playerId, int modify) 
    {
        sliderHealth.value = sliderHealth.value + modify;
    }
    
    private void OnHealthZero(int playerId) 
    { 

    }
   
}
