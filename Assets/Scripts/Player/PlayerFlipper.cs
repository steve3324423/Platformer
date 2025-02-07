using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlayerFlipper : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        transform.Rotate(new Vector2(0, Mathf.Atan2(_mover.Direction.y, _mover.Direction.x) * Mathf.Rad2Deg));
    }
}
