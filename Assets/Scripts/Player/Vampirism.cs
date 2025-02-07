using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerHealth))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private EnemyGetting _enemyGetting;

    private InputReader _inputReader;
    private PlayerHealth _playerHealth;
    private float _timeDuringVampirism = 6f;
    private float _timeForReload = 1.5f;
    private float _maxDistance = 5f;
    private float _damage = 1f;
    private float _maxTime = 6f;
    private bool _isEnabled;

    public event Action TurnOnVampirism;
    public event Action TurnOffVampirism;
    public event Action<float> ChangeValueVampirism;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
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
        if (_timeDuringVampirism > 0 && _isEnabled == false)
            StartCoroutine(EnableVampirism());
    }

    private IEnumerator ReloadVampirism()
    {
        _isEnabled = false;

        while (_timeDuringVampirism < _maxTime && _isEnabled == false)
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
        for(int i = 0; i < _enemyGetting.Enemies.Count; i++)
            TakeHealthEnemy(_enemyGetting.Enemies[i]);
    }

    private void TakeHealthEnemy(EnemyHealth enemy)
    {
        Vector2 offset = enemy.transform.position - transform.position;

        if (enemy.Value > 0 && offset.sqrMagnitude < _maxDistance * _maxDistance)
        {
            TakeDifference(enemy);
            _playerHealth.IncreaseHealth(_damage);
            enemy.TakeDamage(_damage);
        }
    }

    private void TakeDifference(EnemyHealth enemy)
    {
        if (enemy.Value < _damage)
        {
            _playerHealth.IncreaseHealth(enemy.Value);
            enemy.TakeDamage(enemy.Value);

            return;
        }
    }
}
