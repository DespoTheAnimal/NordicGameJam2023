using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal1 : MonoBehaviour
{
    public bool collisionPortal1 = false;
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
        if (other.gameObject.name == "Player 2")
        {
            collisionPortal1 = true;
            Debug.Log("collide1");
        }
        else
        { collisionPortal1 = false; }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionPortal1 = false;
    }
}
