using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _openNowMenu;

    public void OpenMenu(GameObject _menu)
    {
        _openNowMenu.SetActive(false);

        _openNowMenu = _menu;
        _openNowMenu.SetActive(true);
    }

    public void StartGame(GameObject level)
    {
        _openNowMenu.SetActive(false);

        level.SetActive(true);
    }
}
