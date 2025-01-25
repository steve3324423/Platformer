using UnityEngine;

[RequireComponent(typeof(EnemyAttacker))]
[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;
    private float _speed = 2f;

    public Vector3 Target { get; private set; }

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
    }

    private void OnEnable()
    {
        _enemyPatrol.EstablishTarget += OnEstablishTarget;
    }

    private void OnDisable()
    {
        _enemyPatrol.EstablishTarget -= OnEstablishTarget;
    }

    private void Update()
    {
        Move();
    }

    private void OnEstablishTarget(Vector3 target)
    {
        Target = target;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, _speed * Time.deltaTime);
    }
}
