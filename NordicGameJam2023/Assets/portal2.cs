using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal2 : MonoBehaviour
{
    public int collisionPortal2;
    // Start is called before the first frame update
    void Start()
    {
        collisionPortal2 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player2")
        {
            collisionPortal2 = 1;
        }
    }
}
