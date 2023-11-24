using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;

    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _rotationSpeed = 10f;

    private bool rotationInProgress = false;

    private bool _canGo = false;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && _canGo == false)
        {
            _canGo = true;
        }

        if (_canGo)
        {
            _playerBody.velocity = transform.up * _speed;

            if (Input.GetMouseButtonDown(1))
            {
                rotationInProgress = true;
            }

            if (rotationInProgress && Input.GetMouseButton(1))
            {
                transform.Rotate(Vector3.forward * _rotationSpeed);
            }

            if (Input.GetMouseButtonUp(1))
            {
                rotationInProgress = false;
            }
        }
    }
}
