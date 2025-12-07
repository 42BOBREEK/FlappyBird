using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _mouseIndex;

    public event Action MouseClicked;

    private void Update()
    {
        if(Input.GetMouseButtonDown(_mouseIndex))
        {
            MouseClicked?.Invoke();
        }
    }
}
