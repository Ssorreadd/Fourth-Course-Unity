using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedRoration = 5f;

    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        float rotations = -horiz * _speedRoration * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotations);

        Vector3 Dirforward = transform.up;
        Vector3 movement = Dirforward * vert * _speed * Time.deltaTime;

        transform.position += movement;
    }
}
