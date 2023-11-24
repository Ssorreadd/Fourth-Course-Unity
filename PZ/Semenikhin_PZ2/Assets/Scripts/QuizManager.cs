using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI _quizUI;

    [SerializeField] private QuizDataScriptable _quizData;

    private List<Question> _questions;

    private Question _selectedQuestion;

    private void Start()
    {
        _questions = _quizData.questions;

        SelectQuestion();
    }

    private void SelectQuestion()
    {
        _selectedQuestion = _questions[UnityEngine.Random.Range(0, _questions.Count)];

        _quizUI.SetQuestion(_selectedQuestion);
    }

    public bool Answer(string answer)
    {
        bool isCorrectAnswer = false;

        if (answer == _selectedQuestion.correctAnswer)
            isCorrectAnswer = true;

        Invoke("SelectQuestion", 0.4f);

        return isCorrectAnswer;
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImage;
    public AudioClip questionClip;
    public VideoClip questionVideo;
    public List<string> options;
    public string correctAnswer;
}

[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}
