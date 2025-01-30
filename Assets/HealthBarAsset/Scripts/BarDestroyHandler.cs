using UnityEngine;

public class BarDestroyHandler : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.RunOutValue += OnRunOutValue;
    }

    private void OnDisable()
    {
        _health.RunOutValue -= OnRunOutValue;
    }

    private void OnRunOutValue()
    {
        Destroy(transform.parent.gameObject);
    }
}
