using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _launchForce = 500;
    [SerializeField] private float _maxDragDistance = 3.5f;

    private Rigidbody2D _birdBody;
    private SpriteRenderer _spriteRenderer;

    private Vector2 _startPosition;

    private void Awake()
    {
        _birdBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _startPosition = _birdBody.position;
        _birdBody.isKinematic = true;
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

    private void OnMouseUp()
    {
        Vector2 currentPosition = _birdBody.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _birdBody.isKinematic = false;
        _birdBody.AddForce(direction * _launchForce);

        _spriteRenderer.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        float distance = Vector2.Distance(desiredPosition, _startPosition);

        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();

            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }


        _birdBody.position = desiredPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);

        _birdBody.position = _startPosition;
        _birdBody.isKinematic = true;

        _birdBody.velocity = Vector3.zero;
    }
}
