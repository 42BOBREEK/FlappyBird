using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private PlayerBulletsPool _pool;
    [SerializeField] private float _shootingCooldown;
    [SerializeField] private bool _canShoot;

    private IEnumerator DisableCooldown()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_shootingCooldown);

        _canShoot = true;
    }

    public void Shoot()
    {
        if(_canShoot)
        {
            var bullet = _pool.GetObject();

            bullet.transform.position = transform.position;
            bullet.ChangeIsEnemy(false);

            StartCoroutine(DisableCooldown());
        }
    }
}
