using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lapCounter;
    [SerializeField] private TextMeshProUGUI _bestCounter;
    [SerializeField] private TextMeshProUGUI _nicknameLabel;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        _nicknameLabel.text = PlayerPrefs.GetString("Nickname");
        _bestCounter.text = PlayerPrefs.GetInt("BestLap").ToString();
    }

    private int _lapCount = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _lapCount++;

            if (_lapCount > PlayerPrefs.GetInt("BestLap"))
                _bestCounter.text = _lapCount.ToString();

            _lapCounter.text = _lapCount.ToString();
        }
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("BestLap", int.Parse(_bestCounter.text));

        SceneManager.LoadScene("GameScene");
    }

    public void GoToMenu()
    {
        if (int.Parse(_bestCounter.text) > 0)
        {
            PlayerPrefs.SetString("Leaders", $"{PlayerPrefs.GetString("Nickname")}: {_bestCounter.text}\n{PlayerPrefs.GetString("Leaders")}");
        }

        SceneManager.LoadScene("MenuScene");
    }
}
