using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedRoration = 5f;

    [SerializeField] private TextMeshProUGUI _nicknameText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _nicknameText.text = $"Nickname: {PlayerPrefs.GetString("Nickname")}";
    }

    private void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        float rotations = -horiz * _speedRoration * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotations);

        Vector3 Dirforward = transform.up;
        Vector3 movement = Dirforward * vert * _speed * Time.deltaTime;

        transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Start"))
        {
            StartCoroutine(StartTimer());
        }
        else if (collision.CompareTag("Finish"))
        {
            StopAllCoroutines();

            PlayerPrefs.SetString("Leaders",
                $"{PlayerPrefs.GetString("Nickname")}:{_scoreText.text.Remove(0, 5)} сек.\n{PlayerPrefs.GetString("Leaders")}");

            SceneManager.LoadScene("MenuScene");
        }
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            _scoreText.text = "Timer: " + (int.Parse(_scoreText.text.Remove(0, 6)) + 1).ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
