using UnityEngine;

public class playerCollition : MonoBehaviour
{
    public playerControll movement;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstaculo")
        {
            movement.enabled = false;
        }
    }
}
