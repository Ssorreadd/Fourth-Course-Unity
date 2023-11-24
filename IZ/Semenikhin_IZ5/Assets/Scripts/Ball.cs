using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Rigidbody2D _ballBody;

    [SerializeField] private float _launchForceVelocityX = 15f;
    [SerializeField] private float _launchForceVelocityY = 15f;

    private Vector2 _playerVelocity;
    private Vector2 _startPlayerPosition;

    private void Start()
    {
        _startPlayerPosition = _ballBody.position;
        _ballBody.velocity = new Vector2(_launchForceVelocityX, _launchForceVelocityY);
    }

    private void Update()
    {
        _playerVelocity = _ballBody.velocity;
    }

    private void Respawn()
    {
        _ballBody.position = _startPlayerPosition;
        _ballBody.velocity = new Vector2(_launchForceVelocityX, _launchForceVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag.ToLower())
        {
            case "killbox":
                Invoke("Respawn", 0.5f);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.ToLower() == "cube")
        {
            _scoreText.text = (int.Parse(_scoreText.text) + 1).ToString();
            collision.gameObject.SetActive(false);
        }

        Vector2 normal = collision.contacts[0].normal;

        Vector2 newVelocity = Vector2.Reflect(_playerVelocity, normal);

        _ballBody.velocity = newVelocity;
    }
}
