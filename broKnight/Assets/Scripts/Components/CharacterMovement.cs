using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterAbilities
{
    [SerializeField] private float walkSpeed = 6f;

    public float MoveSpeed { get; set; }

     protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
        UpdateAnimation();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimation();
    }

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(HorizontalInput, VerticalInput);
        Vector2 movementNormalized = movement.normalized;
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }

    private void UpdateAnimation()
    {
        if (Mathf.Abs(HorizontalInput) > 0.1f || Mathf.Abs(VerticalInput) > 0.1f)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}
