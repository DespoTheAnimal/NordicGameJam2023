using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal0 : MonoBehaviour
{
    public int collisionPortal0;
    // Start is called before the first frame update
    void Start()
    {
        collisionPortal0 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player0")
        {
            collisionPortal0 = 1;
        }
    }
}
