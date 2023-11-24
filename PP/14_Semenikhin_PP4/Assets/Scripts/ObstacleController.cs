using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.localScale = new Vector3(
                transform.localScale.x - 0.005f,
                transform.localScale.y - 0.005f,
                transform.localScale.z - 0.005f
            );
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
            Destroy(gameObject);
    }
}
