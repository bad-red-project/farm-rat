using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControlMovement : MonoBehaviour
{
    private float moveSpeed = 1f;
    private float BASE_ANIMATION_SPEED = 1f;
    private float OBJECT_MOVEMENT_STABILIZATOR = 5f;
    private float START_SPEED_MOVEMENT_PARAMETER = .01f;

    public Rigidbody2D rb;
    public Animator animator;
    public Joystick joystick;

    private Vector2 movement;

    void Update()
    {
        UpdateMovementCoordinats();
        UpdateAnimatorParameters();
        UpdateAnimatorSpeed();
    }

    void FixedUpdate() { ChangeModelPosition(); }

    private void ChangeModelPosition()
    {
        if (GetAnimatorSpeedParameter() < START_SPEED_MOVEMENT_PARAMETER) { return; }
        rb.MovePosition(rb.position + GetPositionChange());
    }

    private void UpdateMovementCoordinats()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", GetAnimatorSpeedParameter());
    }

    private void UpdateAnimatorSpeed() { animator.speed = GetAnimationSpeed(); }

    private Vector2 GetPositionChange() { return movement * OBJECT_MOVEMENT_STABILIZATOR * moveSpeed * Time.fixedDeltaTime; }

    private float GetAnimationSpeed() { return BASE_ANIMATION_SPEED + movement.sqrMagnitude * moveSpeed; }

    private float GetAnimatorSpeedParameter() { return movement.sqrMagnitude; }
}
