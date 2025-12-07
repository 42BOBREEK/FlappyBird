using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private Bird _player;
    [SerializeField] private EnemyBulletsPool _enemyBulletsPool;
    [SerializeField] private bool _isSpawning;

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isSpawning) 
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var enemy = _pool.GetObject();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;

        var enemyAttacker = enemy.GetComponent<EnemyAttacker>();

        enemyAttacker.ChangeIsShooting(true);
        enemyAttacker.SetPool(_enemyBulletsPool);
        enemyAttacker.StartShooting();
    }
}
