using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizBase _quizBase;
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private List<Button> _answers;
    [SerializeField] private Color _normalColor, _wrongColor, _correctColor;

    private int _questionCount = 0;
    private QuestionType _currentQuestion;

    private void Awake()
    {
        _answers.ForEach(x => x.onClick.AddListener(() => CheckAnswer(x)));

        StartCoroutine(NextQuestion());
    }

    private IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(0.5f);

        _currentQuestion = _quizBase.questions[_questionCount];
        _questionCount++;

        _questionText.text = _currentQuestion.quiestionInfo;

        for (int i = 0; i < _answers.Count; i++)
        {
            _answers[i].GetComponentInChildren<TextMeshProUGUI>().text = _currentQuestion.answers[i];
            _answers[i].image.color = _normalColor;
            _answers[i].name = _currentQuestion.answers[i];
        }
    }

    private void CheckAnswer(Button button)
    {
        button.image.color = button.name == _currentQuestion.correctAnswer ? _correctColor : _wrongColor;

        StartCoroutine(NextQuestion());
    }
}
