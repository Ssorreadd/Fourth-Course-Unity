using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _currentScore;

    private void Start()
    {
        string best = PlayerPrefs.GetString("BestScore");   
        string current = PlayerPrefs.GetString("CurrentScore");

        _bestScore.text = $"������ ����: {(best == "" ? 0 : best)}";
        _currentScore.text = $"������� ����: {(current == "" ? 0 : current)}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
