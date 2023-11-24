using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private GameObject _nextLevel;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetString("OpenLevels", PlayerPrefs.GetString("OpenLevels") + $"{_levelNumber + 1}");

            _currentLevel.SetActive(false);
            _nextLevel.SetActive(true);
        }
    }
}
