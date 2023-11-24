using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _openNowMenu;
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _currentScore;

    private void Start()
    {
        string best = PlayerPrefs.GetString("BestScore");
        string current = PlayerPrefs.GetString("CurrentScore");

        _bestScore.text = $"Лучший счет: {(best == "" ? "0" : best)}";
        _currentScore.text = $"Текущий счет: {(current == "" ? "0" : current)}";
    }

    public void OpenMenu(GameObject _menu)
    {
        _openNowMenu.SetActive(false);

        _openNowMenu = _menu;
        _openNowMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
