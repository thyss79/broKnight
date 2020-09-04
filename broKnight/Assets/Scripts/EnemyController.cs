using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public Animator anim;
    private bool isMoving;

    public int health = 150;

    public GameObject[] deathSplatters;
    public GameObject hitEffect;

    //fire!!
    public bool shouldShoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    public SpriteRenderer body;
    public float shootRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (body.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;
                isMoving = true;
            }
            else
            {
                moveDirection = Vector3.zero;
                isMoving = false;
            }
            moveDirection.Normalize();

            theRB.velocity = moveDirection * moveSpeed;

            if (shouldShoot && (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= shootRange))
            {
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }

        } else
        {
            theRB.velocity = Vector2.zero;
        }


        if (isMoving)
        {
            anim.SetBool("enemyIsMoving", true);
        }
        else
        {
            anim.SetBool("enemyIsMoving", false);
        }
    }

    public void DamageEnemy(int damage)
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        health -= damage;
        if (health <= 0)
        {

            int rotation = Random.Range(0, 4);
            Destroy(gameObject);
            Instantiate(deathSplatters[Random.Range(0,deathSplatters.Length)], transform.position, Quaternion.Euler(0f, 0f, rotation * 90));
        }
    }
}
