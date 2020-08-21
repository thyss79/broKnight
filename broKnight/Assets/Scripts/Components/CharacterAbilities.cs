using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    protected float HorizontalInput;
    protected float VerticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    // main method, here we put the logic of ability
    protected virtual void HandleAbility()
    {
        InternalInput();
    }

    //here we get neccessary input we need to perform our actions
    protected virtual void HandleInput()
    {

    }

    //here we get the main input we need to control our character
    protected virtual void InternalInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }
}
