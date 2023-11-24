using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    private Rigidbody2D _playerBody;
    private Vector2 _playerDiraction;

    private void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        _playerDiraction = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        _playerBody.velocity = new Vector2(0, _playerDiraction.y * _playerSpeed);
    }
}
