using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthViewSliderSmooth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed = 10f;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ChangedHealth += OnChangedHealth;
    }

    private void OnDisable()
    {
        _health.ChangedHealth -= OnChangedHealth;
    }

    private void OnChangedHealth(float value)
    {
        StartCoroutine(ChangeSliderValue(value));
    }

    private IEnumerator ChangeSliderValue(float value)
    {
        float time = 1f;

        while (time > 0)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _speed * Time.deltaTime);
            time -= Time.deltaTime;
            yield return null;
        }
    }
}
