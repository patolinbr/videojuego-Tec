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

    // Start is called before the first frame update
    void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
