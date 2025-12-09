using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private BulletsPool _pool;
    [SerializeField] private float _shootingCooldown;
    [SerializeField] private bool _canShoot;
    [SerializeField] private bool _isShooting;
    [SerializeField] private string _bulletLayerName;

    public void StartShooting() => StartCoroutine(ShootRegularly());

    private IEnumerator DisableCooldown()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_shootingCooldown);

        _canShoot = true;
    }

    private IEnumerator ShootRegularly()
    {
        var secondsToWait = new WaitForSeconds(_shootingCooldown);

        while(_isShooting)
        {
            Shoot();

            yield return secondsToWait;
        }
    }

    public void Shoot()
    {
        if(_canShoot)
        {
            var bullet = _pool.GetObject();

            bullet.transform.position = transform.position;

            bullet.gameObject.layer = LayerMask.NameToLayer(_bulletLayerName);

            Vector2 bulletDirection = transform.right * Mathf.Sign(transform.localScale.x); 

            bullet.ChangeDirections(bulletDirection, bulletDirection);

            StartCoroutine(DisableCooldown());
        }
    }

    public void SetPool(BulletsPool pool) => _pool = pool;

    public void ChangeIsShooting(bool isShooting) => _isShooting = isShooting;

    public void ChangeCanShoot(bool canShoot) => _canShoot = canShoot;
}
