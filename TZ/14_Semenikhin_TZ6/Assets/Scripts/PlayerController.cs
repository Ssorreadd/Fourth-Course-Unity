using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpawnerController _spawner;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private GameObject _gameOverPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ball"))
            return;

        if (collision.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
        {
            Destroy(collision.gameObject);

            var newScore = (int.Parse(_countText.text) + 1).ToString();

            _countText.text = newScore;
            PlayerPrefs.SetString("PlayerScore", newScore);
        }
        else
        {
            _spawner.StopAllCoroutines();
            _gameOverPanel.SetActive(true);
        }
    }
}
