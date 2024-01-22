using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        var positionX = Input.GetAxis("Horizontal");

        var newPosition = transform.position + new Vector3((positionX * Time.deltaTime) * _speed, 0f, 0f);

        if(newPosition.x >= 2.2 || newPosition.x <= -2.2)
        {
            return;
        }
        
        transform.position = newPosition;
    }
}
