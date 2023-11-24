using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _speed = 10;

    private bool[] _haveKeys = { false, false, false };

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _player.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveHorizontal, moveVertical) * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag.ToLower())
        {
            case "key":
                _gameManager.ShowKey(collision.gameObject);
                break;
            case "wintrigger":
                _gameManager.WinEvent();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag.ToLower())
        {
            case "door":
                _gameManager.OpenDoor(collision.gameObject);
                break;
        }
    }
}
