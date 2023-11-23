using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;
    [SerializeField][Range(1f, 10f)] float speedPlayer;
    [SerializeField] private FixedJoystick joystick;

    private Vector2 moveDirection;

    private readonly int moveX = Animator.StringToHash("moveX");
    private readonly int moveY = Animator.StringToHash("moveY");
    private readonly int isMoving = Animator.StringToHash("isMoving");
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        ReadMovement();
    }


    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * speedPlayer * Time.fixedDeltaTime);
    }
    private void ReadMovement()
    {
        moveDirection.x = joystick.Horizontal;
        moveDirection.y = joystick.Vertical;
        moveDirection = moveDirection.normalized;

        if(moveDirection == Vector2.zero)
        {
            animator.SetBool(isMoving, false);
            return;
        }

        animator.SetBool(isMoving, true);
        animator.SetFloat(moveX, moveDirection.x);
        animator.SetFloat(moveY, moveDirection.y);
    }
}
