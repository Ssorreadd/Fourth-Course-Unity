using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leadersList;

    private void OnEnable()
    {
        _leadersList.text = PlayerPrefs.GetString("Leaders");
    }

    public void StartGame()
    {
        var leaders = PlayerPrefs.GetString("Leaders");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetString("Leaders", leaders);

        SceneManager.LoadScene("GameScene");
    }
}
