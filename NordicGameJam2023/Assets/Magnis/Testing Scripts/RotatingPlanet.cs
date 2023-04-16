using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{

    private float rotationSpeed;

    public bool direction;
    //public GameObject anchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void RotatePlanet()
    {
        if (direction)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -1 * rotationSpeed);
            transform.rotation *= rotation;
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 1 * rotationSpeed);
            transform.rotation *= rotation;
        }
 
    }

    public void GetValues(bool toggleDirection, float speed)
    {
        direction = toggleDirection;
        rotationSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RotatePlanet();
    }
}
