using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{
    public int control;
    public GameObject player;

    [SerializeField] GameInput _GI;

    public float rotationSpeed;

    //public GameObject anchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void RotatePlanet()
    {
        Vector2 readValues = _GI.GetMovement();
        Vector3 inputValues = new Vector3(readValues.x, 0, readValues.y);


        if (_GI.GetRotation() == 1)
        {
            Quaternion rotation = Quaternion.Euler(0,0, -1);
            transform.rotation *= rotation;
        }
        else if(_GI.GetRotation() == -1)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 1);
            transform.rotation *= rotation;
        }
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotatePlanet();
    }
}
