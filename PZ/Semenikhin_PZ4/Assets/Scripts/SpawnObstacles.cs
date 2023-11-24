using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;
    [SerializeField] private float _timeBetweenSpawn;
    
    private float _spawnTime;

    private void Update()
    {
        if (Time.time > _spawnTime)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        float randX = Random.Range(_minX, _maxX);
        float randY = Random.Range(_minY, _maxY);

        Instantiate(_obstacle, transform.position + new Vector3(randX, randY, 0), transform.rotation);
    }
}
