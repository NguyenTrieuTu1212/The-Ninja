using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] private Animator animator;

    private readonly int moveX = Animator.StringToHash("moveX");
    private readonly int moveY = Animator.StringToHash("moveY");
    private readonly int isMoving = Animator.StringToHash("isMoving");
    private readonly int Dead = Animator.StringToHash("isDead");
    private readonly int Revival = Animator.StringToHash("isRevival");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SetBoolMoveAnimation(bool value)
    {
        animator.SetBool(isMoving, value);
    }
    

    public void SetMovingAnimation(Vector2 moveDirection)
    {
        animator.SetFloat(moveX, moveDirection.x);
        animator.SetFloat(moveY, moveDirection.y);
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(Dead);
    }

    /*public void SetRivialAnimation(bool value)
    {
        animator.SetBool(Revival, value);
    }*/
}
