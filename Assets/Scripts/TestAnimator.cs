using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(gameObject,transform.position,Quaternion.identity);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null) animator.SetBool("isTest", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isTest", false);
    }
}
