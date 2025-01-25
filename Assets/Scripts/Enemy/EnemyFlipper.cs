using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyFlipper : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        transform.eulerAngles = new Vector2(0, Mathf.Atan2(_enemy.Target.y, _enemy.Target.x) * Mathf.Rad2Deg);
    }
}
