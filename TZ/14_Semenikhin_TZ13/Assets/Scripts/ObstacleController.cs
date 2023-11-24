using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private GameObject _levelSelecter;
    [SerializeField] private GameObject _currentLevel;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _currentLevel.SetActive(false);

            _levelSelecter.SetActive(true);
        }
    }
}
