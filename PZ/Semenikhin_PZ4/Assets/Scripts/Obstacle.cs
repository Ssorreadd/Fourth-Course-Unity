using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag.ToLower())
        {
            case "border":
                Destroy(this.gameObject);
                break;

            case "player":
                Destroy(collision.gameObject);
                break;
        }
    }
}
