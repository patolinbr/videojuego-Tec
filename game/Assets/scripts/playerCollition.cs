using UnityEngine;

public class playerCollition : MonoBehaviour
{
    public playerControll movement;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "obstacle")
        {
            movement.enabled = false;
        }
    }
}
