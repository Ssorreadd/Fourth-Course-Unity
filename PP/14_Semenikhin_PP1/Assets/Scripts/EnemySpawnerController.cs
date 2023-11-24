using System.Collections;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] float _maxY, _minY;
    [SerializeField] float[] _xPoints;
    [SerializeField] float _interval = 0.5f;
    [SerializeField] GameObject _enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(_enemyPrefab, new Vector3(_xPoints[Random.Range(0, _xPoints.Length)], Random.Range(_minY, _maxY)), Quaternion.identity, null);
            yield return new WaitForSeconds(_interval);
        }
    }
}
