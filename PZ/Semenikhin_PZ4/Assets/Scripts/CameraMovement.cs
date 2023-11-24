using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;

    private void Update()
    {
        transform.position += new Vector3(_cameraSpeed * Time.deltaTime, 0, 0);
    }
}
