using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float Value { get; protected set; } = 100f;

    public event Action<float> ChangedHealth;
    public event Action RunOutValue;
    public event Action TakedDamage;

    public void TakeDamage(float damage)
    {
        if(damage > 0)
        {
            Value -= damage;
            TakedDamage?.Invoke();
            ChangedHealth?.Invoke(Value);
        }

        if (Value <= 0)
            RunOutValue?.Invoke();
    }

    protected void ChangedHealthAction(float value)
    {
        ChangedHealth?.Invoke(value);
    }

    protected void TakedDamageAction()
    {
        TakedDamage?.Invoke();
    }
}
