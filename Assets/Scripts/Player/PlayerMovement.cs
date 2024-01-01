using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Player player;
    private PlayerAnimations animations;
    [SerializeField][Range(1f, 10f)] float speedPlayer;
    [SerializeField] private VariableJoystick joystick;
    private Vector2 moveDirection;
    public Vector2 MoveDirection => moveDirection; 


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        animations = GetComponent<PlayerAnimations>();
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
        if (player.Stats.Health <= 0) return;
        rb2d.MovePosition(rb2d.position + moveDirection * speedPlayer * Time.fixedDeltaTime);
    }
    private void ReadMovement()
    {
        moveDirection.x = joystick.Horizontal;
        moveDirection.y = joystick.Vertical;
        moveDirection = moveDirection.normalized;

        if(moveDirection == Vector2.zero)
        {
            animations.SetBoolMoveAnimation(false);
            return;
        }

        animations.SetBoolMoveAnimation(true);
        animations.SetMovingAnimation(moveDirection);
        
    }

    
}
