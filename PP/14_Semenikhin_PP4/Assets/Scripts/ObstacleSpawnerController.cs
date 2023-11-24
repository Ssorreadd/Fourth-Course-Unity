using System.Collections;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2.5f;

    [SerializeField] private GameObject[] _obstaclesPrefabs;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            var obstacle = Instantiate(_obstaclesPrefabs[Random.Range(0, _obstaclesPrefabs.Length)], transform);
            obstacle.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
