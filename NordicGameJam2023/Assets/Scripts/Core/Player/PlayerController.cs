using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerEnterAndExitMechanic playerEnterAndExitMechanic;
    GameInput _GI;

    public bool playerMovementEnabled = true;

    private Rigidbody _RB;

    Vector3 readGoodValues;

    private void Start()
    {
        _GI = FindObjectOfType<GameInput>();
        _RB = GetComponent<Rigidbody>();
        playerEnterAndExitMechanic = GetComponent<PlayerEnterAndExitMechanic>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        readGoodValues = ctx.ReadValue<Vector2>();
        readGoodValues.y = 0;
        readGoodValues.z = 0;
    }



    private void HandleMovement()
    {
        int speedModifier = 5;

        _RB.MovePosition(transform.position + transform.TransformDirection(readGoodValues * speedModifier * Time.deltaTime));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerMovementEnabled)
            HandleMovement();
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.name == "canon")
    //    {

    //    }
    //}
}
