using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCounter;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _bestScoreCounter;

    private int _score = 0;

    public void GameOver()
    {
        Time.timeScale = 0;

        CheckBestScore();

        _bestScoreCounter.text = $"Лучший счет: {PlayerPrefs.GetInt("BestScore")}";

        _gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMenu()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");

        if (bestScore > 0) 
        {
            PlayerPrefs.SetString("Leaders", $"{PlayerPrefs.GetString("Nickname")}: {bestScore} оч.\n{PlayerPrefs.GetString("Leaders")}");
        }

        SceneManager.LoadScene("MenuScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _score++;
            _scoreCounter.text = _score.ToString();
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;

        CheckBestScore();
    }

    private void CheckBestScore()
    {
        if (_score > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", _score);
    }
}
