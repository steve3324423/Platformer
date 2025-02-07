using System.Collections.Generic;
using UnityEngine;

public class EnemyGetting : MonoBehaviour
{
    public List<EnemyHealth> Enemies { get; private set; }

    private void Awake()
    {
        Enemies = new List<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
            DiscoveredEnemy(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
            LostedEnemy(enemy);
    }

    private void LostedEnemy(EnemyHealth enemy)
    {
        Enemies.Remove(enemy);
    }

    private void DiscoveredEnemy(EnemyHealth enemy)
    {
        Enemies.Add(enemy);
    }
}
