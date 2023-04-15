using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
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
        
        Quaternion rotation = Quaternion.Euler(/*inputValues.z * rotationSpeed */0, 0, inputValues.x *rotationSpeed);
        transform.rotation *= rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotatePlanet();
    }
}
