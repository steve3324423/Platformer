using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Health))]
public class Mover : MonoBehaviour
{
    private InputReader _inputReader;
    private Health _health;
    private float _speed = 5f;

    public event Action<float> Running;

    public Vector2 Direction { get;private set; }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.RunOutValue += OnRunOutValue;
    }

    private void OnDisable()
    {
        _health.RunOutValue -= OnRunOutValue;
    }

    private void Update()
    {
        if(enabled == true)
            Move();
    }

    private void Move()
    {
        Direction = transform.right * -_inputReader.Direction;
        transform.Translate(-Direction * _speed * Time.deltaTime);

        Running?.Invoke(_inputReader.Direction);
    }

    private void OnRunOutValue()
    {
        enabled = false;
    }
}
