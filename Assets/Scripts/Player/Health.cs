using System;
using UnityEngine;

[RequireComponent(typeof(Vampirism))]
public class PlayerHealth : Health
{
    public event Action TakedFirstAidKit;

    public void IncreaseHealth(float value)
    {
        if(Value <= 0)
            Value += value;
    }

    public void TakeFirstAidKit(float valueIncrease)
    {
        IncreaseHealth(valueIncrease);
        ChangedHealthAction(Value);
        TakedDamageAction();

        TakedFirstAidKit?.Invoke();
    }
}
