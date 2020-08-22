using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    protected float HorizontalInput;
    protected float VerticalInput;

    protected CharacterController controller;
    protected CharacterMovement characterMovement;
    protected Animator animator;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    // main method, here we put the logic of ability
    protected virtual void HandleAbility()
    {
        InternalInput();
        HandleInput();
    }

    //here we get neccessary input we need to perform our actions
    protected virtual void HandleInput()
    {

    }

    //here we get the main input we need to control our character
    protected virtual void InternalInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }
}
