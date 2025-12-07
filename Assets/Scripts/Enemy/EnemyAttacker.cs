using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private EnemyBulletsPool _pool;
    [SerializeField] private float _shootingCooldown;
    [SerializeField] private bool _isShooting; 

    public void StartShooting() => StartCoroutine(ShootRegularly());

    private IEnumerator ShootRegularly()
    {
        var secondsToWait = new WaitForSeconds(_shootingCooldown);

        while(_isShooting)
        {
            EnemyBullet bullet = _pool.GetObject();

            bullet.transform.position = transform.position;

            yield return secondsToWait;
        }
    }

    public void SetPool(EnemyBulletsPool pool) => _pool = pool;

    public void ChangeIsShooting(bool isShooting) => _isShooting = isShooting;
}
