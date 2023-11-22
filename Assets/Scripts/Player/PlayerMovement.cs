using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField][Range(1f, 10f)] float speedPlayer;
    [SerializeField] private FixedJoystick joystick;

    private Vector2 moveDirection;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        Debug.Log("x: " + joystick.Horizontal + " y: " + joystick.Vertical);
        moveDirection = moveDirection.normalized;
    }
}
