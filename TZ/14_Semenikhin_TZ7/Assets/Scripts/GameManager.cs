using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public void PauseGame()
    {
        Time.timeScale = 0.0f;

        _pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;

        _pausePanel.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        PlayerPrefs.SetString("Leaders", $"{PlayerPrefs.GetString("Leaders")}\n {PlayerPrefs.GetString("PlayerNickname")}: {_scoreText.text} оч.");
    }
}
