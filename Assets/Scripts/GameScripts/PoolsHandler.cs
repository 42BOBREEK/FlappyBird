using UnityEngine;

public class PoolsHandler : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private EnemyBulletsPool _enemyBulletsPool;
    [SerializeField] private PlayerBulletsPool _playerBulletsPool;

    public void ResetAllPools()
    {
        _enemyBulletsPool.ResetAllObjects();
        _enemyPool.ResetAllObjects();
        _playerBulletsPool.ResetAllObjects();
    }
}
