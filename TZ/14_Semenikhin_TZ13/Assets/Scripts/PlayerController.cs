using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private Rigidbody2D _playerBody;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 inputPosition = Input.mousePosition;
            inputPosition.z = 10;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(inputPosition);

            Vector2 direction = (targetPosition - transform.position).normalized;

            _playerBody.velocity = direction * moveSpeed;
        }

    }
}
