using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    public GameObject[] brokenPiaces;
    public int maxPieces = 5;

    public bool shouldDropItems;
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        Destroy(gameObject);
        AudioManager.instance.PlaySFX(0);

        //show broken pieces
        int picesToDrop = Random.Range(1, maxPieces);

        for (int i = 0; i < picesToDrop; i++)
        {
            int randPiace = Random.Range(0, brokenPiaces.Length);
            Instantiate(brokenPiaces[randPiace], transform.position, transform.rotation);
        }


        //drop items
        if (shouldDropItems)
        {
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);
                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerController.instance.dashCounter > 0)
            {
                Smash();
            }
        }
        else if (other.tag == "PlayerBullet")
        {
            Smash();
        }

    }
}
