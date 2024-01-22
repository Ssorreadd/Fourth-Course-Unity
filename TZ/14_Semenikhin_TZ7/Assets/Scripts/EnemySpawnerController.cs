using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 3;

    [SerializeField] private float _maxX, _minX;

    [SerializeField] private GameObject[] _enemies;

    private void Start()
    {
        StartCoroutine(SpawnIslands());
    }

    private IEnumerator SpawnIslands()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);

            var positionX = Random.Range(_minX, _maxX);

            var spawnEnemy = _enemies[Random.Range(0, _enemies.Length)];

            var enemy = Instantiate(spawnEnemy, transform);

            enemy.transform.position = new Vector3(positionX, transform.position.y, spawnEnemy.transform.position.z);
        }
    }
}
