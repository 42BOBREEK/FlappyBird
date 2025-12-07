using System;
using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;

    public event Action EnemyDied;

    private void OnEnable()
    {
        _pool.ObjectSpawned += SubscribeToEnemy;
        _pool.ObjectRemoved += UnsubscribeFromEnemy;
    }

    private void OnDisable()
    {
        _pool.ObjectSpawned -= SubscribeToEnemy;
        _pool.ObjectRemoved -= UnsubscribeFromEnemy;
    }

    private void SubscribeToEnemy(Enemy enemy)
    {
        enemy.CollidedWithBullet += RemoveEnemy;
    }

    private void UnsubscribeFromEnemy(Enemy enemy)
    {
        enemy.CollidedWithBullet -= RemoveEnemy;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        EnemyDied?.Invoke();
        _pool.ReturnObject(enemy);
    }
}
