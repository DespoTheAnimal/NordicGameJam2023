using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{
    [SerializeField] GameInput _GI;

    //public GameObject anchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void RotatePlanet()
    {
        Vector2 readValues = _GI.GetMovement();
        Vector3 inputValues = new Vector3(readValues.x, 0, readValues.y);

        Quaternion rotation = Quaternion.Euler(inputValues.z, 0, -inputValues.x);
        transform.rotation *= rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotatePlanet();
    }
}
