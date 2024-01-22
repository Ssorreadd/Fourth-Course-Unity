using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _openNowMenu;

    private bool isFullScreen;
    private int winW, winH;

    private void Start()
    {
        winW = Screen.width;
        winH = Screen.height;

        isFullScreen = Screen.fullScreen;
    }

    public void OpenMenu(GameObject menu)
    {
        _openNowMenu.SetActive(false);

        _openNowMenu = menu;
        _openNowMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeResolution(string resolution)
    {
        string[] res = resolution.Split('x');

        winW = int.Parse(res[0]);
        winH = int.Parse(res[1]);

        Screen.SetResolution(winW, winH, isFullScreen);
    }

    public void ChangeWindowMode()
    {
        isFullScreen = !isFullScreen;

        Screen.SetResolution(winW, winH, isFullScreen);
    }
}
