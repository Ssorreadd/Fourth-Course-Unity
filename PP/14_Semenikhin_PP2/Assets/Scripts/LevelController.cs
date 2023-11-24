using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] private string _currentLevel;
    [SerializeField] private string _nextLevel;
    [SerializeField] private int _needBoxes;
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private TextMeshProUGUI _boxCount;
    [SerializeField] private GameObject _gameOverPanel;

    private int _upBoxesCount = 0;

    private DateTime _timerValue = new DateTime();

    private void Start()
    {
        _boxCount.text = $"{_upBoxesCount}/{_needBoxes}";
    }

    public IEnumerator Timer()
    {
        while (true)
        {
            _timerValue = _timerValue.AddSeconds(1);

            _timer.text = _timerValue.ToLongTimeString();

            yield return new WaitForSeconds(1);
        }
    }

    public void UpBox()
    {
        _upBoxesCount++;
        _boxCount.text = _boxCount.text = $"{_upBoxesCount}/{_needBoxes}";
    }

    public void CheckBoxCount()
    {
        if (_upBoxesCount == _needBoxes)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        PlayerPrefs.SetString($"{_currentLevel}", _timerValue.Ticks.ToString());

        if (_nextLevel == "MenuScene")
        {
            Win();
            return;
        }

        SceneManager.LoadScene(_nextLevel);
    }

    public void GameOver()
    {
        StopAllCoroutines();

        _gameOverPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Win()
    {
        string leaders = PlayerPrefs.GetString("Leaders");

        long finalTime = 0;

        int currentLevel = int.Parse(_currentLevel.Remove(0, 5).ToString());

        for (int i = 1; i < currentLevel; i++)
        {
            finalTime += long.Parse(PlayerPrefs.GetString($"Level{i}"));
        }

        PlayerPrefs.SetString("Leaders", $"{PlayerPrefs.GetString("Nickname")}, время: {new DateTime(finalTime).ToLongTimeString()}\n{leaders}");

        SceneManager.LoadScene("MenuScene");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_currentLevel);
    }
}
