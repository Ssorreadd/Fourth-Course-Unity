using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;
    void Update()
    {
        transform.position += new Vector3(0f, _cameraSpeed * Time.deltaTime, 0f);
    }
}
