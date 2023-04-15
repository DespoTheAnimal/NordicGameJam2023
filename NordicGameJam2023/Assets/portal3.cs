using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal3 : MonoBehaviour
{
    public int collisionPortal3;
    // Start is called before the first frame update
    void Start()
    {
        collisionPortal3 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player3")
        {
            collisionPortal3 = 1;
        }
    }
}
