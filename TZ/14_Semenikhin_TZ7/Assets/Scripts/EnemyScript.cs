using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject _rocketPrefab;

    private void Start()
    {
        _rocketPrefab = Resources.Load<GameObject>("Prefabs/Game/Rockets/EnemyRocket");
        StartCoroutine(SpawnRockets());
    }

    private void Update()
    {
        transform.position -= new Vector3(0, 2f, 0) * Time.deltaTime;
    }

    private IEnumerator SpawnRockets()
    {
        while (true)
        {
            Instantiate(_rocketPrefab, new Vector3(transform.position.x, transform.position.y + 0.1f), Quaternion.identity);

            yield return new WaitForSeconds(3f);
        }

    }

    private void OnDestroy()
    {
        var particle = Resources.Load<GameObject>("Prefabs/Effects/Particle");
        Instantiate(particle, transform.position, Quaternion.identity, transform.parent);
    }
}