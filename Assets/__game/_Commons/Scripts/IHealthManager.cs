using System;

public interface IHealthManager 
{
    event Action<int,int> OnHealthChange;
    event Action<int> OnHealtZero;
    int GetMaxHealth();
    int GetHealth();
    void ModifyHealt(int modifier);
}
