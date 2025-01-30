using UnityEngine;

[RequireComponent(typeof(EnemyGetting))]
public class PlayerAttacker : MonoBehaviour
{
    private EnemyGetting _enemyGetting;
    private float _damage = 10f;

    private void Awake()
    {
        _enemyGetting = GetComponent<EnemyGetting>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        float minDistance = 1f;
        EnemyHealth enemy = _enemyGetting.GetEnemyNear(minDistance);

        if (Input.GetMouseButton(0) && enemy != null)
            enemy.TakeDamage(_damage);
    }
}
