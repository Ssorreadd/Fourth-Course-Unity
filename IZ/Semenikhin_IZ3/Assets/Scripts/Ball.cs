using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 40f;
    [SerializeField] private float _launchForce = 500f;
    [SerializeField] private float _dampingFactor = 0.9f;

    [SerializeField] private string _nextLevelName;

    [SerializeField] private Rigidbody2D _playerBody;

    private Vector2 _playerVelocity;
    private Vector2 _startPlayerPosition;

    private void Start()
    {
        _playerBody.isKinematic = true;
        _startPlayerPosition = _playerBody.position;
    }
    private void Update()
    {
        _playerVelocity = _playerBody.velocity;
    }

    private void Respawn()
    {
        _playerBody.velocity = Vector2.zero;
        _playerBody.angularVelocity = 0;

        _playerBody.position = _startPlayerPosition;
        _playerBody.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "KillBox":
                Invoke("Respawn", 1.5f);
                break;
            case "WinTrigger":
                Invoke("NextLevel", 1.0f);
                break;
        }
    }

    private void NextLevel()
    {
        if (_nextLevelName != "")
            SceneManager.LoadScene(_nextLevelName);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;

        Vector2 newVelocity = Vector2.Reflect(_playerVelocity, normal);

        _playerBody.velocity = (newVelocity * (_bounceForce *= _dampingFactor)) * Time.deltaTime;
    }

    private void OnMouseUp()
    {
        Vector2 currentPosition = _playerBody.position;
        Vector2 direction = _startPlayerPosition - currentPosition;
        direction.Normalize();

        _playerBody.isKinematic = false;
        _playerBody.AddForce(direction * _launchForce);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;

        if (desiredPosition.x > _startPlayerPosition.x)
            desiredPosition.x = _startPlayerPosition.x;

        float distance = Vector2.Distance(desiredPosition, _startPlayerPosition);

        if (distance > 3)
        {
            Vector2 direction = desiredPosition - _startPlayerPosition;
            direction.Normalize();

            desiredPosition = _startPlayerPosition + (direction * 3);
        }


        _playerBody.position = desiredPosition;
    }
}
