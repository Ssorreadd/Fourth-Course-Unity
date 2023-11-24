using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _openNowMenu;

    public void OpenMenu(GameObject menu)
    {
        _openNowMenu.SetActive(false);

        _openNowMenu = menu;
        _openNowMenu.SetActive(true);
    }

    public void ConfirmNickname(TMP_InputField nicknameInput)
    {
        if (string.IsNullOrWhiteSpace(nicknameInput.text))
        {
            nicknameInput.image.color = Color.red;
            return;
        }

        PlayerPrefs.SetString("PlayerNickname", nicknameInput.text);
        SceneManager.LoadScene("GameScene");
    }
}
