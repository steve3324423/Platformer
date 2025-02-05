using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private Sprite _spriteDead;

    private Color _colorRed;
    private Color _colorGreen;
    private SpriteRenderer _spriteRenderer;
    private PlayerHealth _health;
    private float _timeForInvoke = .5f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<PlayerHealth>();

        _colorGreen = Color.green;
        _colorRed = Color.red;
    }

    private void OnEnable()
    {
        _health.TakedFirstAidKit += OnTakedFirstAidKit;
        _health.RunOutValue += OnRunOutValue;
        _health.TakedDamage += OnTakedDamage;
    }

    private void OnDisable()
    {
        _health.TakedFirstAidKit -= OnTakedFirstAidKit;
        _health.RunOutValue -= OnRunOutValue;
        _health.TakedDamage -= OnTakedDamage;
    }

    private void OnTakedDamage()
    {
        ChangeColor(_colorRed);
    }

    private void OnTakedFirstAidKit()
    {
        ChangeColor(_colorGreen);
    }

    private void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
        Invoke(nameof(SetColorToDefault), _timeForInvoke);
    }

    private void OnRunOutValue()
    {
        _spriteRenderer.sprite = _spriteDead;
    }

    private void SetColorToDefault()
    {
        _spriteRenderer.color = Color.white;
    }
}
