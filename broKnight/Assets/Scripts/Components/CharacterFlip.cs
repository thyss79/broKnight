using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : CharacterAbilities
{
    public enum FlipMode
    {
        MovementDirection,
        WeaponDirection
    }

    [SerializeField] private FlipMode flipMode = FlipMode.MovementDirection;
    [SerializeField] private float treshold = 0.1f;

    protected override void HandleAbility()
    {
        base.HandleAbility();
        if (flipMode == FlipMode.MovementDirection)
        {
            FlipToMoveDirection();
        }
        else
        {
            FlipToWeaponDirection();
        }
    }

    private void FlipToMoveDirection()
    {
        //jesli sie ruszamy...
        if (controller.CurrentMovment.normalized.magnitude > treshold)
        {
            // x > 0 oznacza ruch w prawo
            if (controller.CurrentMovment.normalized.x > 0)
            {
                FaceDirection(1);
            }
            else
            {
                FaceDirection(-1);
            }
        }
    }

    private void FlipToWeaponDirection()
    {

    }

    private void FaceDirection(int newDirection)
    {
        if (newDirection == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
