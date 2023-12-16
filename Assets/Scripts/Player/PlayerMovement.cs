using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IDataPersistance
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Player player;
    [SerializeField][Range(1f, 10f)] float speedPlayer;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private PlayerAnimations animations;
    private Vector2 moveDirection;

    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animations = gameObject.GetComponent<PlayerAnimations>();
        
    }

    public void LoadGame(GameData gameData)
    {
        rb2d.position = gameData.posPlayer;
    }

    public void SaveGame(ref GameData gameData)
    {
        gameData.posPlayer = rb2d.position;
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
