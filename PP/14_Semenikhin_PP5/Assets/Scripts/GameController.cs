using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _timer;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _timerPanel;

    private GameObject _selectedCouple = null;
    private Vector3 _sizeScale = new Vector3(0.05f, 0.05f, 0.05f);

    public delegate void Method(GameObject couple);

    public static Method SetCoupleDelegate;

    private void Start()
    {
        SetCoupleDelegate = SetCouple;

        _bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();

        StartCoroutine(Timer());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();

        Time.timeScale = 1;
    }

    public void Pause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("BestScore", int.Parse(_bestScore.text));

        ReturnToMenu();
    }

    private void AddPoints()
    {
        int score = int.Parse(_score.text);
        int bestScore = int.Parse(_bestScore.text);

        score += 2;

        if (score > bestScore)
        {
            _bestScore.text = score.ToString();
        }

        _score.text = score.ToString();
    }

    public void SetCouple(GameObject couple)
    {
        if(_selectedCouple == null)
        {
            _selectedCouple = couple;
            _selectedCouple.transform.localScale += _sizeScale;

            return;
        }

        if (couple.CompareTag(_selectedCouple.tag) && couple.transform.localScale != _selectedCouple.transform.localScale)
        {
            AddPoints();

            couple.transform.localScale += _sizeScale;

            StartCoroutine(DestroyCouples(_selectedCouple, couple));
        }
        else
        {
            _selectedCouple.transform.localScale -= _sizeScale;
        }

        _selectedCouple = null;
    }

    private IEnumerator DestroyCouples(GameObject couple1, GameObject couple2)
    {
        while (couple1.transform.localScale.x > 0.01f)
        {
            couple1.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            couple2.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);

            yield return new WaitForSeconds(0.001f);
        }

        Destroy(couple1);
        Destroy(couple2);
    }

    private IEnumerator Timer()
    {
        while (int.Parse(_timer.text) != 0)
        {
            _timer.text = (int.Parse(_timer.text) - 1).ToString();
            yield return new WaitForSeconds(1);
        }

        _timerPanel.SetActive(true);

        yield return new WaitForSeconds(2);

        GameOver();
    }
}
