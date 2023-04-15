using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameInput _GI; 

    public float moveSpeed;

    private Vector3 moveDirection;



    private void Update()
    {
        Vector2 readValues = _GI.GetMovement();
        moveDirection = new Vector3(readValues.x, 0, readValues.y);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection));
    }
}
