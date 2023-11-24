using UnityEngine;

public class BoundController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            _gameController.GameOver();
        }
    }
}
