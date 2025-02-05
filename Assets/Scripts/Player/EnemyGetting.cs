using System.Collections.Generic;
using UnityEngine;

public class EnemyGetting : MonoBehaviour
{
    [SerializeField] private Scanner[] _scanners;

    private float _maxDistance = 1f;

    public List<EnemyHealth> Enemies { get; private set; }

    private void Awake()
    {
        Enemies = new List<EnemyHealth>();
    }

    private void OnEnable()
    {
        foreach (Scanner scanner in _scanners)
        {
            scanner.DiscoveredEnemy += OnDiscoveredEnemy;
            scanner.LostedEnemy += OnLostedEnemy;
        }
    }

    private void OnDestroy()
    {
        foreach (Scanner scanner in _scanners)
        {
            scanner.DiscoveredEnemy -= OnDiscoveredEnemy;
            scanner.LostedEnemy -= OnLostedEnemy;
        }
    }

    private void OnLostedEnemy(EnemyHealth enemy)
    {
        Enemies.Remove(enemy);
    }

    private void OnDiscoveredEnemy(EnemyHealth enemy)
    {
        Enemies.Add(enemy);
        Enemies.Sort((enemyFirst, enemySecond) =>
        {
            Vector2 offsetOne = enemyFirst.transform.position - transform.position;
            Vector2 offsetTwo = enemySecond.transform.position - transform.position;

            float distanceOne = offsetOne.sqrMagnitude;
            float distancTwo = offsetTwo.sqrMagnitude;

            return distanceOne.CompareTo(distancTwo);
        });
    }
}
