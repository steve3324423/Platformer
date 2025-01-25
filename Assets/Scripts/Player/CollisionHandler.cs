using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class CollisionHandler : MonoBehaviour
{
    private Health _health;
    private float _maxHealth = 100f;

    public event Action<int> TakedCoin;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item thing))
        {
            if(IsThingeExists(thing) == true)
                thing.Destroy();
        }
    }

    private bool IsThingeExists(Item item)
    {
        if (item is Coin)
        {
            Coin coin = (Coin)item;
            TakedCoin?.Invoke(coin.Value);
            return true;
        }
        
        if (item is FirstAidKit && _health.Value < _maxHealth)
        {
            FirstAidKit firstAidKit = (FirstAidKit)item;
            _health.TakeFirstAidKit(firstAidKit.ValueIncreaseHealth);
            return true;
        }

        return false;
    }
}
