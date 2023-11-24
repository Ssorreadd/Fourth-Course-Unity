using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float[] _spawnPointsX;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Sprite[] _carSprites;
    [SerializeField] private GameObject _carPrefab;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles() 
    {
        yield return new WaitForSeconds(3);

        while(true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void Spawn() 
    {
        var position = _spawnPointsX[Random.Range(0, _spawnPointsX.Length)];
        var sprite = _carSprites[Random.Range(0, _carSprites.Length)];

        var obstacle = Instantiate(_carPrefab, new Vector3(position, transform.position.y), transform.rotation);

        obstacle.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
