using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public bool playerMovementEnabled = true;

    public bool isPlayerOne;

    Vector3 readGoodValues;

    public int speedModifier;

    private void HandleMovement()
    {
        if (isPlayerOne)
        {
            float x = Input.GetAxis("Horizontal_P1");
            readGoodValues = new Vector3(0, 0, -x);
        }
        else
        {
            float x = Input.GetAxis("Horizontal_P2");
            readGoodValues = new Vector3(0, 0, -x);
        }

        Quaternion rotation = Quaternion.Euler(readGoodValues * speedModifier);
        transform.rotation *= rotation;
    }

    void FixedUpdate()
    {
        if (playerMovementEnabled)
            HandleMovement();
    }

    /*[SerializeField] GameInput _GI;

    public float rotationSpeed;

    //public GameObject anchor;


    private void RotatePlanet()
    {
        Vector2 readValues = _GI.GetMovement();
        Vector3 inputValues = new Vector3(readValues.x, 0, readValues.y);
        
        Quaternion rotation = Quaternion.Euler(/*inputValues.z * rotationSpeed 0, 0, -inputValues.x *rotationSpeed);
        transform.rotation *= rotation;
    }


    void FixedUpdate()
    {
        RotatePlanet();
    }*/
}
