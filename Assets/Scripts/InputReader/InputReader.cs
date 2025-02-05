using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    private KeyCode _keyCode = KeyCode.Space;
    private int _buttonKey = 1;

    public float Direction { get; private set; }

    public event Action TouchedKeyJump;
    public event Action VampirizmButtonTouched;

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if(Input.GetMouseButtonDown(_buttonKey))
            VampirizmButtonTouched?.Invoke();

        if (Input.GetKeyDown(_keyCode))
            TouchedKeyJump?.Invoke();
    }
}
