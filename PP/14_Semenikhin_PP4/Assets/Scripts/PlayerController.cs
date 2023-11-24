using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private GameController _gameController;

    private void Update()
    {
        float axisH = Input.GetAxis("Horizontal");

        if (axisH > 0)
            _playerSprite.flipX = true;
        else if (axisH < 0 && axisH != 0)
            _playerSprite.flipX = false;

        transform.RotateAround(Vector3.zero, -new Vector3(0, 0, axisH), _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            _gameController.GameOver();
        }
    }
}
