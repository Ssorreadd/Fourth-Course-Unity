using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _openNowMenu;

    public void OpenMenu(GameObject _menu)
    {
        _openNowMenu.SetActive(false);

        _openNowMenu = _menu;
        _openNowMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
