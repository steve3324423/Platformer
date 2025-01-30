using UnityEngine;

public class EnemyGetting : MonoBehaviour
{
    [SerializeField] private EnemyHealth[] _enemies;

    public EnemyHealth GetEnemyNear(float minDistance)
    {
        foreach (EnemyHealth enemy in _enemies)
        {
            Vector2 offset = enemy.transform.position - transform.position;

            if (offset.sqrMagnitude < minDistance * minDistance)
                return enemy;
        }

        return null;
    }
}
