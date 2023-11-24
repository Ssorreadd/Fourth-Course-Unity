using TMPro;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leadersList;

    private void OnEnable()
    {
        string leaders = PlayerPrefs.GetString("Leaders");

        _leadersList.text = leaders.Length > 0 ? leaders : "Лидеров пока нет"; 
    }
}
