using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NicknameController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nicknameInput;
    [SerializeField] private Button _confirmButton;

    private void Start()
    {
        _confirmButton.onClick.AddListener(() => StartGame());
        _nicknameInput.onValueChanged.AddListener((x) => SetDefaultColor());
    }

    private void StartGame()
    {
        if (!CheckValidation())
        {
            _nicknameInput.image.color = Color.red;
            return;
        }

        Player.GetContext().Info.Nickname = _nicknameInput.text;;

        SceneManager.LoadScene("GameWindow");
    }

    private bool CheckValidation()
    {
        return !string.IsNullOrWhiteSpace(_nicknameInput.text);
    }

    private void SetDefaultColor()
    {
        _nicknameInput.image.color = _nicknameInput.colors.normalColor;
    }
}
