using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    private float moveSpeed = 1f;
    private float BASE_ANIMATION_SPEED = 1f;
    private float OBJECT_MOVEMENT_STABILIZATOR = 5f;
    private float START_SPEED_MOVEMENT_PARAMETER = .01f;

    public Rigidbody2D rb;
    public Animator animator;
    public Joystick joystick;
    public bool isAutoMove = false;

    private Vector2 movement;
    private Vector2 autoMoveTarget;

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
        if (isAutoMove && !GetIsJoystickMovement())
        {
            UpdateAutoMovementCoordinats();
            return;
        }

        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        isAutoMove = false;
    }

    private void UpdateAutoMovementCoordinats()
    {
        Vector2 playerPosition = rb.position;
        float distance = Vector2.Distance(playerPosition, autoMoveTarget);
        if (distance == 0)
        {
            StopAutoMovement();
        }

        movement.x = GetMovementDirectionCoordinat(playerPosition.x, autoMoveTarget.x);
        movement.y = GetMovementDirectionCoordinat(playerPosition.y, autoMoveTarget.y);
    }

    private float GetMovementDirectionCoordinat(float coordinatFrom, float coordinatTo)
    {
        float coordinatDiff = coordinatTo - coordinatFrom;
        if (coordinatDiff > -1 && coordinatDiff < 1 )
            return coordinatDiff;

        return coordinatTo > coordinatFrom ? 1 : -1;
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

    private bool GetIsJoystickMovement()
    {
        return joystick.Horizontal != 0 || joystick.Vertical != 0;
    }

    private void StopAutoMovement()
    {
        isAutoMove = false;
    }
    public void MoveTo(Vector2 target)
    {
        autoMoveTarget = target;
        isAutoMove = true;
    }
}
