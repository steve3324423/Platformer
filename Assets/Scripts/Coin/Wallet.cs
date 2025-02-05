using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private CollisionHandler _playerTakeCoin;

    private int _count = 0;

    public event Action<int> ChangedCountCoin;

    private void OnEnable()
    {
        _playerTakeCoin.TakedCoin += OnTakedCoin;
    }

    private void OnDestroy()
    {
        _playerTakeCoin.TakedCoin -= OnTakedCoin;
    }

    private void OnTakedCoin(int value)
    {
        if(value > 0)
        {
            _count += value;
            ChangedCountCoin?.Invoke(_count);
        }
    }
}
