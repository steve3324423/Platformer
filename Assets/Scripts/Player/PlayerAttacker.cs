using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private EnemyGetting _enemyGetting;

    private float _maxDistance = 1f;
    private float _damage = 10f;

    private void Update()
    {
        if(_enemyGetting.Enemies.Count > 0)
            Attack();
    }

    private void Attack()
    {
        for (int i = 0; i < _enemyGetting.Enemies.Count; i++)
        {
            Vector2 offset = _enemyGetting.Enemies[i].transform.position - transform.position;

            if (offset.sqrMagnitude < _maxDistance * _maxDistance && Input.GetMouseButton(0))
                _enemyGetting.Enemies[i].TakeDamage(_damage);
        }
    }
}
