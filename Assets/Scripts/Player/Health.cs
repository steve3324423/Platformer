using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Value { get; private set; } = 100f;

    public event Action TakedFirstAidKit;
    public event Action RunOutValue;
    public event Action TakedDamage;

    public void TakeDamage(float damage)
    {
        Value -= damage;
        TakedDamage?.Invoke();

        if (Value <= 0)
            RunOutValue?.Invoke();
    }

    public void TakeFirstAidKit(float valueIncrease)
    {
        Value += valueIncrease;
        TakedFirstAidKit?.Invoke();
    }
}
