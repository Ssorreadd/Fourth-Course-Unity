using System.Linq;
using TMPro;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leaders;

    private void OnEnable()
    {
        string leadersList = PlayerPrefs.GetString("LeaderBoard");

        _leaders.text = leadersList == "" ? "Лидеров пока нет" : leadersList;
    }
}
