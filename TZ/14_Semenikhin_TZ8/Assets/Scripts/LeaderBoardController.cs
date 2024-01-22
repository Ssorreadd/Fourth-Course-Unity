using TMPro;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leaderBoard;

    private void OnEnable()
    {
        string leaders = PlayerPrefs.GetString("Leaders");

        _leaderBoard.text = leaders == "" ? "Лидеров пока нет" : leaders;
    }
}
