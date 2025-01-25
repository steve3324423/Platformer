using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    private KeyCode _keyCode = KeyCode.Space;

    public float Direction { get; private set; }

    public event Action TouchedKeyJump;

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_keyCode))
            TouchedKeyJump?.Invoke();
    }
}
