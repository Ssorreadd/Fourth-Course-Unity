using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    public delegate void IntMethod(int value);
    
    public delegate void Method();

    public static Method GameOverDelegate;

    public static IntMethod SetScoreCountDelegate;

    private void Start()
    {
        GameOverDelegate = GameOver;
        SetScoreCountDelegate = SetScoreCount;
    }

    private void SetScoreCount(int count)
    {
        _score.text = $"—чет: {int.Parse(_score.text.Remove(0, 5)) + count}";
    }

    private void GameOver()
    {
        int best = int.Parse(PlayerPrefs.GetString("BestScore") == "" ? "0" : PlayerPrefs.GetString("BestScore"));
        int current = int.Parse(_score.text.Remove(0, 5));

        if (best < current)
        {
            PlayerPrefs.SetString("BestScore", current.ToString());
        }


        PlayerPrefs.SetString("CurrentScore", current.ToString());

        SceneManager.LoadScene("MenuScene");
    }
}
