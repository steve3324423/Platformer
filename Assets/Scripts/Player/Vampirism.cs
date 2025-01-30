using System;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private EnemyGetting _enemyGetting;
    private float _timeDuringVampirism = 6f;
    private float _timeForReload = 1.5f;
    private float _minDistance = 5f;
    private float _damage = 1f;

    public event Action<bool> TurnOnVampirism;
    public event Action<float> ChangeValueVampirism;

    private void Awake()
    {
        _enemyGetting = GetComponent<EnemyGetting>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && _timeDuringVampirism > 0)
            EnableVampirism();
        else if (_timeDuringVampirism <= 6)
            ReloadVampirism();
    }

    private void ReloadVampirism()
    {
        if(_timeDuringVampirism < 6)
        {
            float valueIncrease = Time.deltaTime * _timeForReload;
            _timeDuringVampirism += valueIncrease;

            ChangeValueVampirism?.Invoke(_timeDuringVampirism);
            TurnOnVampirism?.Invoke(false);
        }
    }

    private void EnableVampirism()
    {
        TurnOnVampirism?.Invoke(true);
        EnemyHealth enemy = _enemyGetting.GetEnemyNear(_minDistance);

        if (enemy != null)
            enemy.TakeDamage(_damage);

        _timeDuringVampirism -= Time.deltaTime;
        ChangeValueVampirism?.Invoke(_timeDuringVampirism);
    }
}
