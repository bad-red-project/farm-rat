using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControlMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    public Rigidbody2D rb;
    public Animator animator;
    public Joystick joystick;

    private Vector2 movement;

    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.speed = 1 + movement.sqrMagnitude * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}
