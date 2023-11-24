using UnityEngine;

public class KillBoxController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
}
