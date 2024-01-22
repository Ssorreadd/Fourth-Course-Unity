using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private SpriteRenderer _bgSprite;

    [SerializeField] private Color _startBgColor;

    public void SetColor()
    {
        if (_bgSprite.color != Color.white)
        {
            _bgSprite.color = Color.white;
        }
        else
        {
            _bgSprite.color = _startBgColor;
        }
    }

    public void Exit()
    {
        PlayerPrefs.SetString("Leaders",
            $"{PlayerPrefs.GetString("Nickname")}: {_score.text} оч.\n{PlayerPrefs.GetString("Leaders")}");
        SceneManager.LoadScene("MenuScene");
    }
}
