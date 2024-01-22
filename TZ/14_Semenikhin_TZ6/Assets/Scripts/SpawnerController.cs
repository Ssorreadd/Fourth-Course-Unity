using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float _spawnSpeed = 2;

    [SerializeField] private float _ballGravity = 1;

    [SerializeField] private Color[] _colors;

    [SerializeField] private GameObject _ballPrefab;

    private void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    public IEnumerator SpawnBalls()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            yield return new WaitForSeconds(_spawnSpeed);

            var color = _colors[Random.Range(0, _colors.Length)];

            var ball = Instantiate(_ballPrefab, transform);

            ball.GetComponent<SpriteRenderer>().color = color;
            ball.GetComponent<Rigidbody2D>().gravityScale = _ballGravity;

            _ballGravity += 0.001f;
        }
    }
}
