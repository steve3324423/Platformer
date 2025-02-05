using UnityEngine;

[RequireComponent(typeof(EnemyGetting))]
public class PlayerAttacker : MonoBehaviour
{
    private EnemyGetting _enemyGetting;
    private int _index = 0;
    private float _damage = 10f;

    private void Awake()
    {
        _enemyGetting = GetComponent<EnemyGetting>();
    }

    private void Update()
    {
        if(_enemyGetting.Enemies.Count > 0)
            Attack();
    }

    private void Attack()
    {
        EnemyHealth enemy = _enemyGetting.Enemies[_index];

        if (Input.GetMouseButton(0) && enemy != null)
            enemy.TakeDamage(_damage);
    }
}
