using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _dragonBody;

    private void Start()
    {
        _dragonBody.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _dragonBody.isKinematic = false;

            _dragonBody.velocity = new Vector2(0f, 2f) * _jumpForce;
        }
    }
}
