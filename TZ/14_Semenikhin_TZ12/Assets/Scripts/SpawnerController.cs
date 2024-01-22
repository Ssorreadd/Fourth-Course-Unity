using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;

    [SerializeField] private Vector2 _spawnPoint1, _spawnPoint2, _spawnPoint3;
    
    [SerializeField] private GameObject[] _entitiesPrefabs;

    private void Start()
    {
        StartCoroutine(Spawn(_spawnPoint1));
        StartCoroutine(Spawn(_spawnPoint2));
        StartCoroutine(Spawn(_spawnPoint3));
    }

    private IEnumerator Spawn(Vector2 spawnPoint)
    {
        while (true)
        {
            GameObject entity = _entitiesPrefabs[Random.Range(0, _entitiesPrefabs.Length)];

            yield return new WaitForSeconds(_spawnInterval + Random.Range(-1.0f, 1.0f));

            Instantiate(entity, new Vector3(spawnPoint.x, spawnPoint.y, transform.position.z), Quaternion.identity, transform);
        }
    }
}
