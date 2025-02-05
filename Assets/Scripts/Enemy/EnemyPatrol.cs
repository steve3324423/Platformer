using System;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private EnemyZone _enemyZone;
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private Transform _secondPosition;

    private Vector3 _target;
    private bool _isSeePlayer;

    public event Action<Vector3> EstablishTarget;

    private void OnEnable()
    {
        _enemyZone.PlayerEnteredZone += OnPlayerEnteredZone;
        _enemyZone.PlayerLeftedZone += OnPlayerLeftedZone;
    }

    private void OnDisable()
    {
        _enemyZone.PlayerEnteredZone -= OnPlayerEnteredZone;
        _enemyZone.PlayerLeftedZone -= OnPlayerLeftedZone;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector2 offsetPositionOne = _firstPosition.position - transform.position;
        Vector2 offsetPositionTwo = _secondPosition.position - transform.position;
        float minDistance = .1f;

        if (_isSeePlayer == false && _target != _firstPosition.position && _target != _secondPosition.position)
            SetTarget(_firstPosition.position);
        else if (IsDistanceForSetTarget(offsetPositionOne, offsetPositionTwo, minDistance) == true)
            SetTarget(_secondPosition.position);
        else if (IsDistanceForSetTarget(offsetPositionTwo, offsetPositionOne, minDistance) == true)
            SetTarget(_firstPosition.position);
    }

    private void SetTarget(Vector3 target)
    {
        _target = target;
        EstablishTarget?.Invoke(target);
    }

    private void OnPlayerEnteredZone(PlayerHealth player)
    {
        _isSeePlayer = true;
        _target = player.transform.position;
        EstablishTarget?.Invoke(player.transform.position);
    }

    private void OnPlayerLeftedZone()
    {
        _isSeePlayer = false;
    }

    private bool IsDistanceForSetTarget(Vector2 positionOne, Vector2 positionTwo, float minDistance)
    {
        return positionOne.sqrMagnitude < minDistance * minDistance && positionTwo.sqrMagnitude > minDistance * minDistance;
    }
}
