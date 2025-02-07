using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Mover _player;

    private float _speed = 5f;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 offset = new Vector3(_player.transform.position.x,transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position,offset,_speed * Time.deltaTime);
    }
}
