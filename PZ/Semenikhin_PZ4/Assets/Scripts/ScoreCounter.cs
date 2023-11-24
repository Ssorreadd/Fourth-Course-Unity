using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    
    private float _score;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            _score += 1f * Time.deltaTime;
            _scoreText.text = ((int)_score).ToString();
        }
    }
}
