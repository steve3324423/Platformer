using System;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public event Action<PlayerHealth> PlayerEnteredZone;
    public event Action PlayerLeftedZone;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
            PlayerEnteredZone?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Mover player))
            PlayerLeftedZone?.Invoke();
    }
}
