using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnterAndExitMechanic : MonoBehaviour
{
    //public enum MechanicState { 
    //    Player, 
    //    Canon,
    //    PlanetRotate,
    //}

    //public MechanicState mechanicState;

    //PlayerController playeController;
    //CanonShoot canonShoot;
    //RotatingPlanet rotatingPlanet;

    //private GameInput gameInput;

    string mechanicTypeInCollider;

    //bool hasEntered = false;

    [SerializeField] private bool isPlayerOne;

    [SerializeField] private bool canEnter = false;





    //public bool rotateEnabled = false;

    //private Transform planet;
    //public Transform playerPositionOfTheMechanic;

    //[SerializeField] GameInput _GI;

    //private void RotatePlanet()
    //{

    //    Vector2 readValues = _GI.GetMovement();
    //    Vector3 inputValues = new Vector3(readValues.x, 0, 0);

    //    //Debug.Log(inputValues);


    //    if (inputValues.x >= .95f)
    //    {
    //        Quaternion rotation = Quaternion.Euler(0, 0, -1);
    //        planet.rotation *= rotation;
    //    }
    //    else if (inputValues.x <= -.95f)
    //    {
    //        Quaternion rotation = Quaternion.Euler(0, 0, 1);
    //        planet.rotation *= rotation;
    //    }

    //}



    private void Awake()
    {
        //playeController = FindObjectOfType<PlayerController>();
        //canonShoot = FindObjectOfType<CanonShoot>();
        //rotatingPlanet = FindObjectOfType<RotatingPlanet>();
        //planet = FindObjectOfType<FauxGravityAttractor>().gameObject.transform;
        //playerPositionOfTheMechanic = GameObject.FindGameObjectWithTag("PlanetRotateChild").transform;
        //_GI = FindObjectOfType<GameInput>();
    }

    private void Start()
    {
        //mechanicState = MechanicState.Player;
        //gameInput = FindObjectOfType<GameInput>();
        //gameInput.PlayerInput.Controls.EnterExit.performed += EnterExit_performed;
    }

    //bool test;

    

    //public void EnterExit_performed(InputAction.CallbackContext ctx)
    //{
    //    test = ctx.ReadValueAsButton();

    //    if(test)
    //    {
    //        if (canEnter)
    //        {
    //            if (mechanicTypeInCollider == "canon" && !hasEntered)
    //            {
    //                playeController.playerMovementEnabled = false;
    //                playeController.transform.position = canonShoot.playerPositionOfTheMechanic.position;

    //                canonShoot.EnableCanon(true);
    //                // enable canon
    //                hasEntered = true;
    //                mechanicState = MechanicState.Canon;
    //            }
    //            else if (mechanicTypeInCollider == "PlanetRotator" && !hasEntered)
    //            {
    //                playeController.playerMovementEnabled = false;
    //                playeController.transform.position = rotatingPlanet.playerPositionOfTheMechanic.position;

    //                rotatingPlanet.rotateEnabled = true;

    //                mechanicState = MechanicState.PlanetRotate;
    //                hasEntered = true;
    //            }
    //            else if (hasEntered)
    //            {
    //                canonShoot.EnableCanon(false);
    //                rotatingPlanet.rotateEnabled = false;

    //                playeController.playerMovementEnabled = true;

    //                mechanicState = MechanicState.Player;
    //                hasEntered = false;
    //            }

    //        }
    //    }
    //}




    private void Update()
    {
        if(isPlayerOne)
        {
            if (Input.GetButtonDown("EnterExit_P1"))
            {

                Debug.Log("EnterExit_P1");
            }
        }
        else
        {
            if (Input.GetButtonDown("EnterExit_P2"))
            {

                Debug.Log("EnterExit_P2");
            }
        }
        


        //if (rotateEnabled)
        //    RotatePlanet();


        //if(mechanicState == MechanicState.Canon || mechanicState == MechanicState.PlanetRotate)
        //{
        //    if(Input.GetKeyDown(KeyCode.I))
        //    {
        //        canonShoot.EnableCanon(false);
        //        rotatingPlanet.rotateEnabled = false;

        //        playeController.playerMovementEnabled = true;

        //        mechanicState = MechanicState.Player;
        //    }
        //}
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Mechanic")
        {
            canEnter = true;

            ColliderChecker cC = other.GetComponent<ColliderChecker>();

            if (other.name == "canon" && cC.otherCollider == this.name)
            {
                mechanicTypeInCollider = "canon";
            }
            else if(other.name == "PlanetRotator" && cC.otherCollider == this.name)
            {
                mechanicTypeInCollider = "PlanetRotator";
            }
            else
            {
                mechanicTypeInCollider = "";
            }
        }
        else
        {
            canEnter = false;
            mechanicTypeInCollider = "";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canEnter = false;
        mechanicTypeInCollider = "";
    }
}
