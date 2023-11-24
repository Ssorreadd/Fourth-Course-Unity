using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    public void ReturnToMenu()
    {
        var leaders = PlayerPrefs.GetString("Leaders");

        PlayerPrefs.SetString("Leaders", $"{_moneyText.text.Remove(0, 7)}\n{leaders}");

        SceneManager.LoadScene("MenuScene");
    }
}
