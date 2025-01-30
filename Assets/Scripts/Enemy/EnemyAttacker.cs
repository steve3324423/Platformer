using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;

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
        _player.RunOutValue += OnRunOutValue;
    }

    private void OnDisable()
    {
        _player.RunOutValue -= OnRunOutValue;
    }

    private IEnumerator ComparePlayerDistance()
    {
        while (enabled)
        {
            Vector2 offsetPlayerPosition = _player.transform.position - transform.position;
            float minDistancePlayerForAttack = 1f;

            if (IsPlayerNear(offsetPlayerPosition, minDistancePlayerForAttack) == true)
                _player.TakeDamage(_damage);

            yield return _waitSeconds;
        }
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
