using TMPro;
using UnityEngine;

public class BestScoreMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _attemptScore;

    private void OnEnable()
    {
        string best = PlayerPrefs.GetString("BestScore");
        string current = PlayerPrefs.GetString("CurrentScore");
        string attempts = PlayerPrefs.GetString("AttemptScore");

        _bestScore.text = $"Лучший результат: {(best == "" ? "0" : best)}";
        _currentScore.text = $"Текущий результат: {(current == "" ? "0" : current)}";
        _attemptScore.text = $"Всего попыток: {(attempts == "" ? "0" : attempts)}";
    }
}
