using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private LayerMask _enemyLayers;

    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _handler;
    private Attacker _attacker;

    public event Action GameOver;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<CollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
        _input.MouseClicked += Shoot;
        _input.JumpClicked += Jump;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
        _input.MouseClicked -= Shoot;
        _input.JumpClicked -= Jump;
    }

    private void ProcessCollision(Collider2D coll)
    {
        if((_enemyLayers.value & (1 << coll.gameObject.layer)) != 0)
            GameOver?.Invoke();
    }

    private void Jump() => _birdMover.Jump();

    private void Shoot() => _attacker.Shoot();

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}
