using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _gameOverText.gameObject.SetActive(true);
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameOverText.gameObject.SetActive(true);
        Destroy(collision.gameObject);
    }
}
