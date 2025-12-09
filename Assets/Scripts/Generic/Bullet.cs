using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;

    private Vector2 _movementDirection;
    private Vector2 _rotationDirection;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.right = _rotationDirection;
        transform.Translate(_movementDirection * _speed * Time.deltaTime, Space.World);
    }

    public void ChangeDirections(Vector2 movementDirection, Vector2 rotationDirection)
    {
        _movementDirection = movementDirection;
        _rotationDirection = rotationDirection;
    }
}
