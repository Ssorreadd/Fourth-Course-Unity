using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;

    private void OnEnable()
    {
        _bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
