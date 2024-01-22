using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TripolyBaseScript _tripolyBase;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image _background;

    private void Start()
    {
        _tripolyBase.SetRectColors(_buttons, _background, _tripolyBase.tripolies[0]);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
