using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] _couplesPrefab;

    [SerializeField] private float _spawnRangeX, _spawnRangeY;

    private bool _isSpawning = false;

    private void Update()
    {
        if (_isSpawning || transform.childCount > 0) return;

        StartCoroutine(SpawnCouples());
    }

    private IEnumerator SpawnCouples()
    {
        _isSpawning = true;

        yield return new WaitForSeconds(0.15f);

        for (int i = 0; i < 4; i++)
        {
            GameObject couple = _couplesPrefab[Random.Range(0, _couplesPrefab.Length)];

            Spawn(couple);
            Spawn(couple);
        }

        _isSpawning = false;

        yield return null;
    }

    private void Spawn(GameObject couple)
    {
        Instantiate(couple,
            new Vector3(
                Random.Range(-_spawnRangeX, _spawnRangeX),
                Random.Range(-3.5f, _spawnRangeY),
                transform.position.z
            ),
            Quaternion.identity,
            transform
        );
    }
}
