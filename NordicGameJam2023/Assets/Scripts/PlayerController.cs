using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameInput _GI;

    public int speedModifier = 0;

    private Rigidbody _RB;
    private void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void HandleMovement()
    {
        Vector2 readValues = _GI.GetMovement();
        Vector3 inputValues = new Vector3(readValues.x, 0, readValues.y);


        _RB.MovePosition(transform.position + inputValues * speedModifier * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }
}
