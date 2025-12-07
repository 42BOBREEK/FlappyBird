using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _handler;
    private PlayerAttacker _attacker;

    public event Action GameOver;

    private void Awake()
    {
        _attacker = GetComponent<PlayerAttacker>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
        _input.MouseClicked += Shoot;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
        _input.MouseClicked -= Shoot;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is EnemyBullet || interactable is Ground || interactable is Enemy)
        {
            GameOver?.Invoke();
        }
    }

    private void Shoot() => _attacker.Shoot();

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}
