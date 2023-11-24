using UnityEngine;

public class PickupRotator : MonoBehaviour
{
    void Start()
    {
   
    }

    void Update() => transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
}
