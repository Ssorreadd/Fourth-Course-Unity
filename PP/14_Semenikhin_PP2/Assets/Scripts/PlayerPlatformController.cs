using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _levelController.CheckBoxCount();
    }
}
