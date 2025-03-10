using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Back", false);
        animator.ResetTrigger("Jump");

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Move", true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Back", true);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
}
