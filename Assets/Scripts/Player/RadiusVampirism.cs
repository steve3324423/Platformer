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
    }

    private void OnDisable()
    {
        _playerVampirism.TurnOnVampirism -= OnTurnOnVampirism;
    }

    private void OnTurnOnVampirism(bool isEnabled)
    {
        _spriteRenderer.enabled = isEnabled;
    }
}
