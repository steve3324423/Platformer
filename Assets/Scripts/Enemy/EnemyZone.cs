using System;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public event Action<Transform> PlayerEnteredZone;
    public event Action PlayerLeftedZone;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Mover player))
            PlayerEnteredZone?.Invoke(player.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Mover player))
            PlayerLeftedZone?.Invoke();
    }
}
