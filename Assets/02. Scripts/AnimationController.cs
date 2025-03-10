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
        animator.SetBool("IsMove", false);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsMove", true);
        }
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsMove", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsMove", true);
        }
    }
}
