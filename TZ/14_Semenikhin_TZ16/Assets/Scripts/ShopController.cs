using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cashText;

    private void Start()
    {
        _cashText.text = PlayerPrefs.GetInt("Cash").ToString();
    }

    public void GoBack()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PrevScene"));
    }
}
