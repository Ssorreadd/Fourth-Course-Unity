using System.Collections;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 5;

    [SerializeField] private float _maxX, _minX;
    
    [SerializeField] private GameObject[] _islands;

    private void Start()
    {
        StartCoroutine(SpawnIslands());
    }

    private IEnumerator SpawnIslands()
    {
        while (true)
        {
            var positionX = Random.Range(_minX, _maxX);

            var spawnIsland = _islands[Random.Range(0, _islands.Length)];

            var island = Instantiate(spawnIsland, transform);

            island.transform.position = new Vector3(positionX, transform.position.y, island.transform.position.z);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
