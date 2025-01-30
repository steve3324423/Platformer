using UnityEngine;

[RequireComponent(typeof(EnemyAttacker))]
[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    private EnemyHealth _health;
    private EnemyPatrol _enemyPatrol;
    private float _speed = 2f;

    public Vector3 Target { get; private set; }

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _enemyPatrol.EstablishTarget += OnEstablishTarget;
        _health.RunOutValue += OnRunOutValue;
    }

    private void OnDisable()
    {
        _enemyPatrol.EstablishTarget -= OnEstablishTarget;
        _health.RunOutValue -= OnRunOutValue;
    }

    private void Update()
    {
        Move();
    }

    private void OnEstablishTarget(Vector3 target)
    {
        Target = target;
    }

    private void OnRunOutValue()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, _speed * Time.deltaTime);
    }
}
