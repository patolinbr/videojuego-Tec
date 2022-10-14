using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructorObstaculos : MonoBehaviour
{
    public float scrollFactor = -1;
    public Vector3 gameVelocity;


    public Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;



    }


    private void OnCollisionEnter(Collision collision)
    {
        

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Destructor")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "jugador")
        {
            
            //SceneManager.LoadScene(sceneBuildIndex: 1);

            FindObjectOfType<GameManager>().gameOver();
            
            
        }


    }

 



}
