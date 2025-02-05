using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(EnemyGetting))]
public class Vampirism : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerHealth _playerHealth;
    private EnemyGetting _enemyGetting;
    private float _timeDuringVampirism = 6f;
    private float _timeForReload = 1.5f;
    private float _damage = 1f;
    private float _maxTime = 6f;
    private int _index = 0;
    private bool _isEnabled;

    public event Action TurnOnVampirism;
    public event Action TurnOffVampirism;
    public event Action<float> ChangeValueVampirism;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _enemyGetting = GetComponent<EnemyGetting>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _inputReader.VampirizmButtonTouched += OnVampirizmButtonTouched;
    }

    private void OnDisable()
    {
        _inputReader.VampirizmButtonTouched -= OnVampirizmButtonTouched;
    }

    private void OnVampirizmButtonTouched()
    {
        if (_timeDuringVampirism > 0 && !_isEnabled)
            StartCoroutine(EnableVampirism());
    }

    private IEnumerator ReloadVampirism()
    {
        _isEnabled = false;

        while (_timeDuringVampirism < _maxTime && !_isEnabled)
        {
            float valueIncrease = Time.deltaTime * _timeForReload;
            _timeDuringVampirism += valueIncrease;

            ChangeValueVampirism?.Invoke(_timeDuringVampirism);
            TurnOnVampirism?.Invoke();

            yield return null;
        }
    }

    private IEnumerator EnableVampirism()
    {
        _isEnabled = true;

        while (_timeDuringVampirism > 0)
        {
            TurnOffVampirism?.Invoke();

            if (_enemyGetting.Enemies.Count > 0)
                ExhaustionHealthEnemy();

            _timeDuringVampirism -= Time.deltaTime;
            ChangeValueVampirism?.Invoke(_timeDuringVampirism);

            yield return null;
        }

        if (_timeDuringVampirism < _maxTime)
            StartCoroutine(ReloadVampirism());
    }

    private void ExhaustionHealthEnemy()
    {
        EnemyHealth enemy = _enemyGetting.Enemies[_index];
        Vector2 offset = enemy.transform.position - transform.position;
        float maxDistance = 3f;

        if (enemy != null && offset.sqrMagnitude < maxDistance * maxDistance)
            TakeHealthEnemy(enemy);
    }

    private void TakeHealthEnemy(EnemyHealth enemy)
    {
        if(enemy.Value > 0)
        {
            _playerHealth.IncreaseHealth(_damage);
            enemy.TakeDamage(_damage);
        }
    }
}
