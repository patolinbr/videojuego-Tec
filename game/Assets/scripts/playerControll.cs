using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControll : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 jumpSpeed;
    bool isGrounded = false;
    bool isAlive = true;
    Rigidbody rb;
    float score;
    public Text ScoreText;
    public GameObject obstacle;
    private GameObject questionBoard;
    private int activations = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
        score = 0;
        questionBoard = GameObject.Find("TriviaCanvas");

        questionBoard.GetComponent<QuestionManager>().Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (score != 0 && score - (activations * 20) > 20)
        {
            Debug.Log("Starting question");
            activations++;
            questionBoard.GetComponent<QuestionManager>().Show();
            Time.timeScale = 0f;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = jumpSpeed;
            
            isGrounded = false;
            FindObjectOfType<AudioManafer>().Play("salto");
        }

        if(isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = "PUNTOS : " + score.ToString("F");

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        

        if (collision.gameObject.tag=="obstacle")
        {
            isAlive = false;
            Time.timeScale = 0;
        }
        
    }

   

}
