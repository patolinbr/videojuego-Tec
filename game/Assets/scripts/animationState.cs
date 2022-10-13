using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationState : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool jumpPressed = Input.GetKey(KeyCode.Space);

        if (jumpPressed)
        {
            animator.SetBool("jump", true);
        }

        if (!jumpPressed)
        {
            animator.SetBool("jump", false);
        }
    }
}
