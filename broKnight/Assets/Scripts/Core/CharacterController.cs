using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Vector2 CurrentMovment { get; set; }

    private Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 currentMovePosition = myRigidbody2D.position + CurrentMovment * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(currentMovePosition);
    }

    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovment = newPosition;
    }
}
