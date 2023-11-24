using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private GameObject _rocketPrefab;

    [SerializeField] private HealthBarController _healthBar;
    [SerializeField] private GameManager _gameManager;

    private float _health = 1.00f;

    private void Start()
    {
        TimerController.StartTimerDelegate();
        StartCoroutine(SpawnRockets());
    }

    private void OnDestroy()
    {
        TimerController.StopTimerDelegate();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 newPos = transform.position + new Vector3(horizontal, vertical, 0) * _speed * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(newPos.x, -2.16f, 2.16f), Mathf.Clamp(newPos.y, -4.47f, 4.47f));
    }

    private IEnumerator SpawnRockets()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.35f);

            Instantiate(_rocketPrefab, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f), Quaternion.identity);
            Instantiate(_rocketPrefab, new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRocket"))
        {
            Destroy(collision.gameObject);

            _health -= 0.10f;
            _healthBar.SetHealth(_health);
        }

        if (_health <= 0)
        {
            _gameManager.GameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _health -= 100f;
            _healthBar.SetHealth(_health);

            _gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
