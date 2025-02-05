using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private EnemyZone _enemyZone;

    private PlayerHealth _player;
    private float _timeForCoroutine = .5f;
    private WaitForSeconds _waitSeconds;
    private Coroutine _coroutine;
    private float _damage = 10f;

    private void Awake()
    {
        _waitSeconds = new WaitForSeconds(_timeForCoroutine);
        _coroutine = StartCoroutine(ComparePlayerDistance());
    }

    private void Start()
    {
        StartCoroutine(ComparePlayerDistance());
    }

    private void OnEnable()
    {
        _enemyZone.PlayerEnteredZone += OnPlayerEnteredZone;
        _enemyZone.PlayerLeftedZone += OnPlayerLeftedZone;
    }

    private void OnDisable()
    {
        _enemyZone.PlayerEnteredZone -= OnPlayerEnteredZone;
        _enemyZone.PlayerLeftedZone -= OnPlayerLeftedZone;
        _player.RunOutValue -= OnRunOutValue;
    }

    private void OnPlayerEnteredZone(PlayerHealth player)
    {
        _player = player;
        _player.RunOutValue += OnRunOutValue;
    }

    private void OnPlayerLeftedZone()
    {
        _player = null;
    }

    private IEnumerator ComparePlayerDistance()
    {
        while (enabled)
        {
            if (_player != null)
                Attaked();

            yield return _waitSeconds;
        }
    }

    private void Attaked()
    {
        Vector2 offsetPlayerPosition = _player.transform.position - transform.position;
        float minDistancePlayerForAttack = 1f;

        if (IsPlayerNear(offsetPlayerPosition, minDistancePlayerForAttack) == true)
            _player.TakeDamage(_damage);
    }

    private bool IsPlayerNear(Vector2 playerPosition, float minDistance)
    {
        return playerPosition.sqrMagnitude < minDistance * minDistance;
    }

    private void OnRunOutValue()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }
}
