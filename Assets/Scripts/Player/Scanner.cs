using System;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public event Action<EnemyHealth> DiscoveredEnemy;
    public event Action<EnemyHealth> LostedEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
            DiscoveredEnemy?.Invoke(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
            LostedEnemy?.Invoke(enemy);
    }
}
