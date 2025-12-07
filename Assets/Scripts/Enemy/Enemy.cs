using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _movementSpeed;

    private EnemyCollisionHandler _handler;
    private Rigidbody2D _rigidbody;

    public event Action<Enemy> CollidedWithBullet;

    private void Awake()
    {
        _handler = GetComponent<EnemyCollisionHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _handler.CollisionDetected += ProcessCollision;

    private void OnDisable() => _handler.CollisionDetected -= ProcessCollision;

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is PlayerBullet)
        {
            CollidedWithBullet?.Invoke(this);
        }
    }

    private void Update() => transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
}
