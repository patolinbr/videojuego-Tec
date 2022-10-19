using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public List<string> questions = new();

    private Dictionary<int, List<Tuple<string, bool>>> _answers = new();

    private List<GameObject> _answerInstances = new();

    public GameObject AnswerObject;

    public GameObject QuestionTextObject;

    public GameObject AnswersContainerObject;

    private int _currentQuestionIndex = 0;

    public void AddQuestion(string question)
    {
        Debug.Log("Adding question");

        questions.Add(question);
    }

    public void AddCorrectAnswer(string answer)
    {
        Debug.Log("Adding correct answer");
        if (!_answers.ContainsKey(questions.Count - 1)) _answers.Add(questions.Count - 1, new());
        _answers[questions.Count - 1].Add(new(answer, true));
    }

    public void AddWrongAnswer(string answer)
    {
        Debug.Log("Adding wrong answer");
        if (!_answers.ContainsKey(questions.Count - 1)) _answers.Add(questions.Count - 1, new());
        _answers[questions.Count - 1].Add(new(answer, false));
    }

    public void Reset()
    {
        _currentQuestionIndex = 0;
    }

    private void Awake()
    {
        Debug.Log("Trivia canvas awake");
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < _answers[_currentQuestionIndex].Count; index++)
        {
        }
        // var answerButton = answer.GetComponent(typeof(Button)) as Button;

        // if (answer.CompareTag("correct"))
        // {
        // answerButton.onClick.AddListener(CorrectAnswer);
        // }
        // else
        // {
        // answerButton.onClick.AddListener(WrongAnswer);
        // }
    }

    public void Show()
    {
        Debug.Log("Setting question text");
        QuestionTextObject.GetComponent<TextMeshProUGUI>().text = questions[_currentQuestionIndex];

        Debug.Log("Getting answer list");
        var answers = _answers[_currentQuestionIndex];

        for (int i = 0; i < answers.Count; i++)
        {
            var answer = answers[i];
            Debug.Log("creating answer instance");
            var answerObject = Instantiate(AnswerObject, AnswersContainerObject.transform);

            _answerInstances.Add(answerObject);

            Debug.Log("Setting answer button listener");
            var answerButton = answerObject.GetComponent<Button>();

            if (answer.Item2)
            {
                answerButton.onClick.AddListener(CorrectAnswer);
            }
            else
            {
                answerButton.onClick.AddListener(WrongAnswer);
            }

            Debug.Log("Setting answer object text");
            answerObject.GetComponent<TextMeshProUGUI>().text = answer.Item1;
        }

        QuestionTextObject.SetActive(true);
        AnswersContainerObject.SetActive(true);
    }


    void CorrectAnswer()
    {
        Debug.Log("Right!");
        Time.timeScale = 1f;

        foreach (var answerObject in _answerInstances)
        {
            Destroy(answerObject);
        }

        _answerInstances = new();

        _currentQuestionIndex++;

        QuestionTextObject.SetActive(false);
        AnswersContainerObject.SetActive(false);
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong!");
        Time.timeScale = 1f;

        QuestionTextObject.SetActive(false);
        AnswersContainerObject.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}