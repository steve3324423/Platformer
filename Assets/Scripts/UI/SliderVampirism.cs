using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVampirism : MonoBehaviour
{
    [SerializeField] private Vampirism _playerVampirism;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _playerVampirism.ChangeValueVampirism += OnChangeValueVampirism;
    }

    private void OnDisable()
    {
        _playerVampirism.ChangeValueVampirism -= OnChangeValueVampirism;
    }

    private void OnChangeValueVampirism(float value)
    {
        _slider.value = value;  
    }
}
