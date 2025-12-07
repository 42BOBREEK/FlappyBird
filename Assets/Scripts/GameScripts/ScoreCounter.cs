using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemyRemover _enemyRemover;

    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _enemyRemover.EnemyDied += Add;
    }

    private void OnDisable()
    {
        _enemyRemover.EnemyDied -= Add;
    }

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
