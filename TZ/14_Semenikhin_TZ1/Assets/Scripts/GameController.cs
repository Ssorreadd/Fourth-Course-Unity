using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cubeText;
    [SerializeField] private TextMeshProUGUI _clicksText;

    public delegate void Method(int cubes);
    public static Method UpdateStatsDelegate;

    private void Start()
    {
        UpdateStatsDelegate = UpdateStats;
    }

    public void ClickCube()
    {
        UpdateStats(1);

        _clicksText.text = $"Clicks: {int.Parse(_clicksText.text.Remove(0, 7)) + 1}";
    }

    private void UpdateStats(int cubes)
    {
        int total = PlayerPrefs.GetInt("Cube") + cubes;

        PlayerPrefs.SetInt("Cube", total);

        _cubeText.text = $"Cube: {total}";
    }

    public void Exit()
    {
        int cubes = PlayerPrefs.GetInt("Cube");
        int best = PlayerPrefs.GetInt("BestCube");

        if (cubes > best)
        {
            PlayerPrefs.SetString("Leaders",
                $"{PlayerPrefs.GetString("Nickname")}: {cubes} cube\n{PlayerPrefs.GetString("Leaders")}" 
            );

            PlayerPrefs.SetInt("BestCube", cubes);
        }

        SceneManager.LoadScene("MenuScene");
    }
}
