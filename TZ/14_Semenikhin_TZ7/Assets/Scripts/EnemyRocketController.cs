using UnityEngine;

public class EnemyRocketController : MonoBehaviour
{
    private void Update()
    {
        transform.position -= new Vector3(0, 4f, 0) * Time.deltaTime;

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
