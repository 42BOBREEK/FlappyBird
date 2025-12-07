using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isEnemyBullet;

    private Rigidbody2D _rigidbody;

    public bool IsEnemyBullet => _isEnemyBullet;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_isEnemyBullet)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void ChangeIsEnemy(bool isEnemyBullet) => _isEnemyBullet  = isEnemyBullet;
}
