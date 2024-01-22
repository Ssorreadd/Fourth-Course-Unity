using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _showNowMenu;

    public void ShowMenu(GameObject menu)
    {
        _showNowMenu.SetActive(false);

        _showNowMenu = menu;
        _showNowMenu.SetActive(true);
    }

    public void ConfirmNickname(TMP_InputField nicknameInput)
    {
        PlayerPrefs.SetString("PlayerNickname", nicknameInput.text);
        SceneManager.LoadScene("GameScene");
    }
}
