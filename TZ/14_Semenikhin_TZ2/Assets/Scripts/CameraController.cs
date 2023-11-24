using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerContainer;
    private Vector3 _offset;

    void Start()
    {
        _offset = new Vector3(0, 0, Camera.main.transform.position.z - _playerContainer.GetChild(0).position.z);
    }

    void Update()
    {
        transform.position = _playerContainer.GetChild(0).position + _offset;
    }
}
