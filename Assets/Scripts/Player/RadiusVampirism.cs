using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RadiusVampirism : MonoBehaviour
{
    [SerializeField] private Vampirism _playerVampirism;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    private void OnEnable()
    {
        _playerVampirism.TurnOnVampirism += OnTurnOnVampirism;
        _playerVampirism.TurnOffVampirism += OnTurnOffVampirism;
    }

    private void OnDisable()
    {
        _playerVampirism.TurnOnVampirism -= OnTurnOnVampirism;
        _playerVampirism.TurnOffVampirism -= OnTurnOffVampirism;
    }

    private void OnTurnOnVampirism()
    {
        _spriteRenderer.enabled = false;
    }

    private void OnTurnOffVampirism()
    {
        _spriteRenderer.enabled = true;
    }
}
