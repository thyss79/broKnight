using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

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
        //myRigidbody2D.MovePosition(myRigidbody2D.position + movment * speed * Time.fixedDeltaTime);
    }
}
