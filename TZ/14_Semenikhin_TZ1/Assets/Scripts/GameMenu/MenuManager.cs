using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _leaderButton;
    [SerializeField] private Transform _menuCanvas;

    void Start()
    {
        LeadersBase.GetContext();
        

        _newGameButton.onClick.AddListener(() => StartNewGame());
        _leaderButton.onClick.AddListener(() => ShowLeaders());
    }

    private void StartNewGame()
    {
        _menuCanvas.Find("NicknamePanel").gameObject.SetActive(true);
        _menuCanvas.Find("MenuPanel").gameObject.SetActive(false);
    }

    private void ShowLeaders()
    {
        SceneManager.LoadScene("LeadersWindow");
    }
}
