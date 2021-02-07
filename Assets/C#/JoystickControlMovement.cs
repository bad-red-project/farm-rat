using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControlMovement : MonoBehaviour
{
    private float moveSpeed = 1f;
    private float BASE_ANIMATION_SPEED = 1f;
    private float OBJECT_MOVEMENT_STABILIZATOR = 5f;

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
        animator.speed = getAnimationSpeed();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + getPositionChange());
    }

    private Vector2 getPositionChange()
    {
        return movement * OBJECT_MOVEMENT_STABILIZATOR * moveSpeed * Time.fixedDeltaTime;
    }

    private float getAnimationSpeed()
    {
        float animationSpeed = BASE_ANIMATION_SPEED + movement.sqrMagnitude * moveSpeed;

        return animationSpeed;
    }
}
