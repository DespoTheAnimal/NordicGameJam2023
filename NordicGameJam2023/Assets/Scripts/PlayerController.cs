using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] GameInput _GI;

    private Rigidbody _RB;
    private void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void HandleMovement()
    {
        Vector2 readValues = _GI.GetMovement();
        Vector3 inputValues = new Vector3(readValues.x, 0, 0);

        int speedModifier = 5;


        _RB.MovePosition(transform.position + transform.TransformDirection(inputValues * speedModifier * Time.deltaTime));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }
}
