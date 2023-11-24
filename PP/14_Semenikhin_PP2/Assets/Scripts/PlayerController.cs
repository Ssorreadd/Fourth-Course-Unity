using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _rotateSpeed = 10;

    [SerializeField] private LevelController _levelController;

    private void LateUpdate()
    {
        float axisH = Input.GetAxis("Horizontal");

        if (axisH != 0)
        {
            _levelController.StartCoroutine(_levelController.Timer());

            _playerBody.gravityScale = 0;

            if (axisH > 0 && axisH <= 1)
            {
                RotateRight();
            }
            else if (axisH < 0 && axisH >= -1)
            {
                RotateLeft();
            }


            _playerBody.velocity = transform.up * _speed;    
        }
        else
        {
            _levelController.StopAllCoroutines();

            _playerBody.gravityScale = 0.5f;

             SetNormalState();
        }

        if (_playerBody.rotation > 45)
        {
            _playerBody.MoveRotation(45);
        }
        else if (_playerBody.rotation < -45)
        {
            _playerBody.MoveRotation(-45);
        }
    }
    
    private void SetNormalState()
    {
        if (_playerBody.rotation > -1 && _playerBody.rotation < 1)
        {
            return;
        }

        if (_playerBody.rotation > 0)
            transform.Rotate(new Vector3(0, 0, _playerBody.rotation - 1 * _rotateSpeed) * Time.fixedDeltaTime);
        else
            transform.Rotate(new Vector3(0, 0, _playerBody.rotation + 1 * _rotateSpeed) * Time.fixedDeltaTime);
    }

    private void RotateLeft()
    {
        if (_playerBody.rotation < 45f)
        {
            transform.Rotate(new Vector3(0, 0, _playerBody.rotation + 1 * _rotateSpeed) * Time.fixedDeltaTime);
        }
    }

    private void RotateRight()
    {
        if (_playerBody.rotation > -45f)
        {
            transform.Rotate(new Vector3(0, 0, _playerBody.rotation - 1 * _rotateSpeed) * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag.ToLower())
        {
            case "box":
                _levelController.UpBox();
                Destroy(collision.gameObject);
                break;
            case "obstacle":
                _levelController.GameOver();
                Destroy(gameObject);
                break;
        }
    }
}
