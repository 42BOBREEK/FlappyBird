using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private LayerMask _playerLayer;

    private CollisionHandler _handler;
    private Rigidbody2D _rigidbody;

    public event Action<Enemy> CollidedWithBullet;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _handler.CollisionDetected += ProcessCollision;

    private void OnDisable() => _handler.CollisionDetected -= ProcessCollision;

    private void ProcessCollision(Collider2D coll)
    {
        if((_playerLayer.value & (1 << coll.gameObject.layer)) != 0)
            CollidedWithBullet?.Invoke(this);
    }

    private void Update() => transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
}
