using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerEnterAndExitMechanic playerEnterAndExitMechanic;
    GameInput _GI;

    public bool playerMovementEnabled = true;

    public bool isPlayerOne;

    private Rigidbody _RB;

    Vector3 readGoodValues;

    public int speedModifier;

    private void Start()
    {
        _GI = FindObjectOfType<GameInput>();
        _RB = GetComponent<Rigidbody>();
        playerEnterAndExitMechanic = GetComponent<PlayerEnterAndExitMechanic>();
        ToggleWeapon();
    }


    

    //private void HandleInteraction()
    //{
    //    if (isPlayerOne)
    //    {
    //        float x = Input.GetAxis("Horizontal_P1");
    //        readGoodValues = new Vector3(x, 0, 0);
    //    }
    //    else
    //    {
    //        float x = Input.GetAxis("Horizontal_P2");
    //        readGoodValues = new Vector3(x, 0, 0);
    //    }

    //    //EnterExit_P1
    //}

    public GameObject[] weapons;
    bool toggle = false;
    [SerializeField] private GameObject weaponToggle;
    [SerializeField] private Transform weaponToggleFXTransform;

    public void ToggleWeapon()
    {
        GameObject clone = Instantiate(weaponToggle, weaponToggleFXTransform.position, Quaternion.identity);
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
            readGoodValues = new Vector3(x, 0, 0);
        }
        else
        {
            float x = Input.GetAxis("Horizontal_P2");
            readGoodValues = new Vector3(x, 0, 0);
        }

        

        speedModifier = 5;

        transform.Translate(readGoodValues * speedModifier * Time.deltaTime);
    }

    void Update()
    {
        if(playerMovementEnabled)
            HandleMovement();

        if(isPlayerOne)
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


}
