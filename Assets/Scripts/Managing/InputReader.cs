using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _mouseIndex;
    [SerializeField] private KeyCode _jumpKey;

    public event Action MouseClicked;
    public event Action JumpClicked;

    private void Update()
    {
        if(Input.GetMouseButtonDown(_mouseIndex))
        {
            MouseClicked?.Invoke();
        }

        if (Input.GetKeyDown(_jumpKey))
        {
            JumpClicked?.Invoke();
        }
    }
}
