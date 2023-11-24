using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject _startHousePrefab;
    [SerializeField] private GameObject[] _housePrefabs;

    [SerializeField] private Transform _crane;
    
    [SerializeField] private Transform _camera;

    public delegate IEnumerator Method();

    public static Method SpawnNewHouseBlockDelegate;

    private void Start()
    {
        SpawnNewHouseBlockDelegate = SpawnNewHouseBlock;
        Instantiate(_startHousePrefab, new Vector3(transform.position.x, transform.position.y), Quaternion.identity, transform);
    }

    public IEnumerator SpawnNewHouseBlock()
    {
        Vector3 newPos = new Vector3(0, 0.05f, 0);

        float maxPosY = _camera.transform.position.y + 1.3f;

        while (_camera.position.y <= maxPosY)
        {
            _camera.position += newPos;
            _crane.position += newPos;

            yield return new WaitForSeconds(0.02f);
        }

        Instantiate(_housePrefabs[Random.Range(0, _housePrefabs.Length)], new Vector3(transform.position.x, transform.position.y), Quaternion.identity, transform );
    }
}
