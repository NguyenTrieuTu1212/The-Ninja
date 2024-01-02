using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null) animator.SetBool("isDestroy", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isDestroy", false);
    }
}
