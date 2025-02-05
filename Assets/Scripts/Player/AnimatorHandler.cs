using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerHealth))]
public class AnimatorHandler : MonoBehaviour
{
    private const string JumpAnimationName = "jump_hero";
    private const string IdleAnimationName = "idle_hero";
    private const string RunAnimationName = "run_hero";

    private Mover _player;
    private Jumper _jumpPlayer;
    private Animator _animator;
    private PlayerHealth _health;
    private bool _isJump;

    private void Awake()
    {
        _jumpPlayer = GetComponent<Jumper>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Mover>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.RunOutValue += OnRunOutValue;
        _jumpPlayer.Jumped += OnJumped;
        _player.Running += OnRunning;
    }

    private void OnDestroy()
    {
        _health.RunOutValue -= OnRunOutValue;
        _jumpPlayer.Jumped -= OnJumped;
        _player.Running -= OnRunning;
    }

    private void OnRunning(float direction)
    {
        if (direction != 0 && _isJump == false)
            _animator.Play(GetAnimation(RunAnimationName));
        else if (_isJump == false)
            _animator.Play(GetAnimation(IdleAnimationName));
    }

    private void OnRunOutValue()
    {
        _animator.enabled = false;
    }

    private int GetAnimation(string nameAnimation)
    {
        return Animator.StringToHash(nameAnimation);
    }

    private void OnJumped(bool isJump)
    {
        _animator.Play(GetAnimation(JumpAnimationName));
        _isJump = isJump;
    }
}
