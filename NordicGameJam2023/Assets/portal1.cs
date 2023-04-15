using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal1 : MonoBehaviour
{
    public int collisionPortal1;
    // Start is called before the first frame update
    void Start()
    {
        collisionPortal1 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player1")
        {
            collisionPortal1 = 1;
        }
    }
}
