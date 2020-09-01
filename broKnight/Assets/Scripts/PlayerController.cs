using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed = 5f;
    private Vector2 moveInput;

    public Rigidbody2D theRB;

    public Transform gunHand;

    private Camera theCam;

    public Animator anim;

    public GameObject bulletToFire;
    public Transform fireFromPoint;

    [SerializeField ]
    public float timeBeetwenShots = 0.2f;
    private float shotCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        //normalizujemy szybkosc tuchu po ukosie
        moveInput.Normalize();
        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0f);
        theRB.velocity = moveInput * moveSpeed;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1, 1f, 1f);
            gunHand.localScale = new Vector3(-1, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunHand.localScale = Vector3.one;
        }

        ////rotate gun
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunHand.rotation = Quaternion.Euler(0, 0, angle);


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, fireFromPoint.position, fireFromPoint.rotation);
            shotCounter = timeBeetwenShots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                Instantiate(bulletToFire, fireFromPoint.position, fireFromPoint.rotation);
                shotCounter = timeBeetwenShots;
            }
        }









        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
