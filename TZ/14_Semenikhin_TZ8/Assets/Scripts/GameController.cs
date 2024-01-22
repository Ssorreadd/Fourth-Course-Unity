using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    public void Exit()
    {
        PlayerPrefs.SetString("Leaders",
            $"{PlayerPrefs.GetString("Nickname")}: {_score.text.Remove(0, 6)} оч.\n{PlayerPrefs.GetString("Leaders")}");
        SceneManager.LoadScene("MenuScene");
    }
}
