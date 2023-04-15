using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerEnterAndExitMechanic playerEnterAndExitMechanic;
    /*[SerializeField]*/ GameInput _GI;

    public bool playerMovementEnabled = true;

    private Rigidbody _RB;
    private void Start()
    {
        _GI = FindObjectOfType<GameInput>();
        _RB = GetComponent<Rigidbody>();
        playerEnterAndExitMechanic = GetComponent<PlayerEnterAndExitMechanic>();
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
