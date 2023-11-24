using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager _quizManager;

    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private Image _questionImage;
    [SerializeField] private VideoPlayer _questionVideo;
    [SerializeField] private AudioSource _questionAudio;
    [SerializeField] private List<Button> _options;
    [SerializeField] private Color _correctColor, _wrongColor, _normalColor;

    private float _audioLenght;

    private Question _question;
    private bool _answered;

    void Awake()
    {
        _options.ForEach(x => x.onClick.AddListener(() => onClick(x)));
    }

    public void SetQuestion(Question question)
    {
        this._question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                SetTextQuestion();
                break;
            case QuestionType.IMAGE:
                SetImageQuestion();
                break;
            case QuestionType.VIDEO:
                SetVideoQuestion();
                break;
            case QuestionType.AUDIO:
                SetAudioQuestion();
                break;
        }

        _questionText.text = _question.questionInfo;
        var answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i = 0; i < _options.Count; i++)
        {
            _options[i].GetComponentInChildren<Text>().text = answerList[i];
            _options[i].name = answerList[i];
            _options[i].image.color = _normalColor;
        }

        _answered = false;
    }

    private void SetTextQuestion()
    {
        _questionImage.transform.parent.gameObject.SetActive(false);
    }

    private void SetImageQuestion()
    {
        ImageHolder();

        _questionImage.transform.gameObject.SetActive(true);
        _questionImage.sprite = _question.questionImage;
    }

    private void SetVideoQuestion()
    {
        ImageHolder();

        _questionVideo.transform.gameObject.SetActive(true);
        _questionVideo.clip = _question.questionVideo;

        _questionVideo.Play();
    }

    private void SetAudioQuestion()
    {
        ImageHolder();

        _questionAudio.transform.gameObject.SetActive(true);

        _audioLenght = _question.questionClip.length;

        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        if (_question.questionType == QuestionType.AUDIO)
        {
            _questionAudio.PlayOneShot(_question.questionClip);

            yield return new WaitForSeconds(_audioLenght + 0.5f);

            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    private void ImageHolder()
    {
        _questionImage.transform.parent.gameObject.SetActive(true);
        _questionImage.transform.gameObject.SetActive(false);
        _questionVideo.transform.gameObject.SetActive(false);
        _questionAudio.transform.gameObject.SetActive(false);
    }

    private void onClick(Button button)
    {
        if (!_answered)
        {
            _answered = true;

            button.image.color = _quizManager.Answer(button.name) ? _correctColor : _wrongColor;
        }
    }
}
