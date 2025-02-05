using UnityEngine;

public class SliderRotation : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _ownerBar;

    private float _yPosition = 1f;

    private void Update()
    {
        transform.parent.position = new Vector2(_ownerBar.position.x,_ownerBar.position.y + _yPosition);
        transform.eulerAngles = new Vector2(_camera.rotation.x, _camera.rotation.y);
    }
}
