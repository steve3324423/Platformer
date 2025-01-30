using System;
using UnityEngine;

public class PlayerHealth : Health
{
    public event Action TakedFirstAidKit;

    public void TakeFirstAidKit(float valueIncrease)
    {
        Value += valueIncrease;
        ChangedHealthAction(Value);
        TakedDamageAction();

        TakedFirstAidKit?.Invoke();
    }
}
