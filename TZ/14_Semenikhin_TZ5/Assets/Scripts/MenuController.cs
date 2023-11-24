using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    private GameObject _openNow;

    private void Start()
    {
        _openNow = _gameMenu;
    }

    public void OpenMenu(GameObject menu)
    {
        _openNow.SetActive(false);

        _openNow = menu;
        _openNow.SetActive(true);
    }

    public void ConfirmNickname(TMP_InputField inputField)
    {
        PlayerPrefs.SetString("Nickname", inputField.text);
        SceneManager.LoadScene("GameScene");
    }
}
