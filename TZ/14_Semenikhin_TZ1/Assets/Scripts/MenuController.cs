using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _openNow;

    public void OpenMenu(GameObject menu)
    {
        _openNow.SetActive(false);

        _openNow = menu;
        _openNow.SetActive(true);
    }

    public void ConfirmNickname(TMP_InputField nicknameInput)
    {
        if(string.IsNullOrWhiteSpace(nicknameInput.text))
        {
            return;
        }

        ClearPrefs();

        PlayerPrefs.SetString("Nickname", nicknameInput.text);

        SceneManager.LoadScene("Game");
    }

    private void ClearPrefs()
    {
        string leaders = PlayerPrefs.GetString("Leaders");
        int best = PlayerPrefs.GetInt("BestCube");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetString("Leaders", leaders);
        PlayerPrefs.SetInt("BestCube", best);
    }
}
