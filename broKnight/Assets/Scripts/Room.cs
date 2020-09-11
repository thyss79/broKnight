using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool closeWhenEnter;
    public GameObject[] doors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);
            
            if (closeWhenEnter)
            {
                foreach (GameObject door in doors)
                {
                    door.SetActive(true);
                }
            }
        }
    }
}
