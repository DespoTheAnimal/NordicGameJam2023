using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{
    public bool rotateEnabled = false;
    public int control;
    public GameObject player;

    [SerializeField] private Transform planet;
    public Transform playerPositionOfTheMechanic;

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
        Vector3 inputValues = new Vector3(readValues.x, 0, 0);

        if (inputValues.x == 1)
        {
            Quaternion rotation = Quaternion.Euler(0,0, -1);
            planet.rotation *= rotation;
        }
        else if(inputValues.x == -1)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 1);
            planet.rotation *= rotation;
        }
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rotateEnabled)
            RotatePlanet();
    }
}
