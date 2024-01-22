using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private TextMeshProUGUI _cashText;
    [SerializeField] private Sprite _openLevelSprite, _currentLevelSprite;

    private void Start()
    {
        _cashText.text = PlayerPrefs.GetInt("Cash").ToString();

        int lastOpenLevel = PlayerPrefs.GetInt("lastOpenLevel");

        foreach (var levelButton in _levelButtons)
        {
            int buttonLevelCount = int.Parse(levelButton.GetComponentInChildren<TextMeshProUGUI>().text);

            if (lastOpenLevel <= 1 && buttonLevelCount == 1)
            {
                levelButton.image.sprite = _currentLevelSprite;
                levelButton.interactable = true;
                break;
            }

            if (lastOpenLevel > buttonLevelCount)
            {
                levelButton.image.sprite = _openLevelSprite;
                levelButton.interactable = true;
            }
            else if (lastOpenLevel == buttonLevelCount)
            {
                levelButton.image.sprite = _currentLevelSprite;
                levelButton.interactable = true;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }
}
