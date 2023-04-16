
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public PlayerInputMap PlayerInput;




    private void Awake()
    {
        PlayerInput = new PlayerInputMap();
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    public Vector2 GetMovement()
    {
        Vector2 readValue = PlayerInput.Controls.Movement.ReadValue<Vector2>().normalized;

        return readValue;
    }
}
