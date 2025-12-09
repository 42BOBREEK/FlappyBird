using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletsPool _bulletsPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemyPool.ReturnObject(enemy);
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletsPool.ReturnObject(bullet);
        }
    }
}
