using UnityEngine;

public class IslandController : MonoBehaviour
{
    private void Update()
    {
        transform.position -= new Vector3(0, 1f, 0) * Time.deltaTime;
    }
}
