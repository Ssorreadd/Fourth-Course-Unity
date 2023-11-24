using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _nicknameMenu;
    [SerializeField] private GameObject _leaderBoard;

    private GameObject _openNow;

    void Start()
    {
        _gameMenu.SetActive(false);
        _nicknameMenu.SetActive(false);
        _leaderBoard.SetActive(false);
        
        _openNow = _gameMenu;
        _openNow.SetActive(true);
    }

    public void OpenMenu(GameObject menu) 
    {
        _openNow.SetActive(false);

        _openNow = menu;
        _openNow.SetActive(true);
    }

    public void ConfirmNickname(TMP_InputField inputField) 
    {
        PlayerPrefs.SetString("PlayerNickname", inputField.text);
        SceneManager.LoadScene("GameScene");
    }
}
