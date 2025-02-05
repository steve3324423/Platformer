using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerHealth))]
public class Jumper : MonoBehaviour
{
    private InputReader _inputReader;
    private Rigidbody2D _rigidbody;
    private PlayerHealth _health;
    private bool _isJump = true;
    private float _force = 10f;

    public event Action<bool> Jumped;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _inputReader.TouchedKeyJump += OnTouchedKeyJump;
        _health.RunOutValue += OnRunOutValue;
    }

    private void OnDisable()
    {
        _inputReader.TouchedKeyJump -= OnTouchedKeyJump;
        _health.RunOutValue -= OnRunOutValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TilemapCollider2D ground))
        {
            _isJump = true;
            Jumped?.Invoke(false);
        }
    }

    private void OnTouchedKeyJump()
    {
        if (_isJump && enabled)
        {
            _rigidbody.AddForce(transform.up * _force, ForceMode2D.Impulse);
            Jumped?.Invoke(_isJump);
            _isJump = false;
        }
    }

    private void OnRunOutValue()
    {
        enabled = false;
    }
}
