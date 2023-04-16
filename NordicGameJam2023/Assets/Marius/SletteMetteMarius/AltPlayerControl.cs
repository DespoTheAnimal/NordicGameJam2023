using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerControl : MonoBehaviour
{
    public bool playerMovementEnabled = true;
    public bool isPlayerOne;
    bool toggle = false;

    Vector3 readGoodValues;
    public int speedModifier;

    public GameObject[] weapons;


    private void Start()
    {
        /*_GI = FindObjectOfType<GameInput>();
        _RB = GetComponent<Rigidbody>();
        playerEnterAndExitMechanic = GetComponent<PlayerEnterAndExitMechanic>();*/
        ToggleWeapon();
    }

    public void ToggleWeapon()
    {
        foreach (var item in weapons)
        {
            item.SetActive(false);
        }

        if (toggle)
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            toggle = false;
        }
        else
        {

            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            toggle = true;

        }
    }

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
        {
            HandleMovement();
        }
    }

    private void Update()
    {
        if (isPlayerOne)
        {
            if (Input.GetButtonDown("EnterExit_P1"))
            {
                ToggleWeapon();
            }
        }
        else
        {
            if (Input.GetButtonDown("EnterExit_P2"))
            {
                ToggleWeapon();
            }
        }
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
