using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private SpawnerController _spawner;

    [SerializeField] private Button _newTryButton;
    [SerializeField] private TextMeshProUGUI _playerStats;

    [SerializeField] private GameObject[] _background;
    [SerializeField] private Color _backgroundColor, _borderColor;

    private bool _noMoreTry = false;

    private void OnEnable()
    {
        if (_noMoreTry)
        {
            _newTryButton.gameObject.SetActive(false);
        }

        _noMoreTry = true;

        _playerStats.text = $"{PlayerPrefs.GetString("PlayerNickname")}: {PlayerPrefs.GetString("PlayerScore")}";
    }

    public void NewTry()
    {
        foreach (var item in _background)
        {
            item.GetComponent<SpriteRenderer>().color = item.gameObject.CompareTag("Border") ? _borderColor : _backgroundColor;
        }

        _spawner.StartCoroutine(_spawner.SpawnBalls());

        gameObject.SetActive(false);
    }

    public void GoToMenu()
    {
        PlayerPrefs.SetString("LeaderBoard", $"{PlayerPrefs.GetString("LeaderBoard")}\n{_playerStats.text}");

        PlayerPrefs.SetString("PlayerNickname", "");
        PlayerPrefs.SetString("PlayerScore", "");

        SceneManager.LoadScene("MenuScene");
    }
}
