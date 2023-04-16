using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal0 : MonoBehaviour
{
    public bool collisionPortal0 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1")
        {
            collisionPortal0 = true;
            Debug.Log("collide0");
        }
        else
        { collisionPortal0 = false; }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionPortal0 = false;
    }
}
