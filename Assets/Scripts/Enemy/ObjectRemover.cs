using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private PlayerBulletsPool _playerBulletsPool;
    [SerializeField] private EnemyBulletsPool _enemyBulletsPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemyPool.ReturnObject(enemy);
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            if(bullet.IsEnemyBullet)
                _enemyBulletsPool.ReturnObject(bullet);
            else
                _playerBulletsPool.ReturnObject(bullet);
        }
    }
}
