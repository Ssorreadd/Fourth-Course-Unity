using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _enemyBody;

    private Vector3 _targetPosition = Vector3.zero;

    private int _healths = 8;

    private void Start()
    {
        _enemyBody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (transform.position.x > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }

        float distance = Vector3.Distance(transform.position, _targetPosition);

        _enemyBody.MoveRotation(Quaternion.LookRotation(_enemyBody.velocity));
        transform.position = Vector3.Lerp(transform.position, _targetPosition, 0.1f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            _healths--;
        }

        if (_healths == 0)
        {
            Destroy(gameObject);
        }

        Destroy(collision.gameObject);
    }
}
