using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public string questionText;

    public List<GameObject> answers;

    private int _currentQuestion = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void AddQuestion(string question)
    {
    }

    void AddRightAnswer(string answer)
    {
    }

    void AddWrongAnswer(string answer)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var answer in answers)
        {
            var answerButton = answer.GetComponent(typeof(Button)) as Button;

            if (answer.CompareTag("correct"))
            {
                answerButton.onClick.AddListener(CorrectAnswer);
            }
            else
            {
                answerButton.onClick.AddListener(WrongAnswer);
            }
        }
    }


    void CorrectAnswer()
    {
        Debug.Log("Right!");
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong!");
        Time.timeScale = 1f;

        gameObject.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    // Update is called once per frame
    void Update()
    {
    }
}