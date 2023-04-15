using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnterAndExitMechanic : MonoBehaviour
{
    public enum MechanicState
    {
        Player,
        Canon,
        PlanetRotate,
    }

    public MechanicState mechanicState;

    PlayerController playeController;
    CanonShoot canonShoot;
    RotatingPlanet rotatingPlanet;

    //private GameInput gameInput;

    string mechanicTypeInCollider;

    bool hasEntered = false;

    [SerializeField] private bool isPlayerOne;

    [SerializeField] private bool canEnter = false;





    public bool rotateEnabled = false;

    [SerializeField] private Transform planet;
    public Transform playerPositionOfTheMechanic;

    //[SerializeField] GameInput _GI;

    private void RotatePlanet()
    {
        float x;

        if (isPlayerOne)
        {
            x = Input.GetAxis("Horizontal_P1");
        }
        else
        {
            x = Input.GetAxis("Horizontal_P2");
        }

        Debug.Log(x);


        if (x >= .95f)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -1 * planetRotationSpeed * Time.deltaTime);
            planet.rotation *= rotation;
        }
        else if (x <= -.95f)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 1 * planetRotationSpeed * Time.deltaTime);
            planet.rotation *= rotation;
        }

    }

    [SerializeField] private float planetRotationSpeed = 0.3f;

    private void Awake()
    {
        playeController = GetComponent<PlayerController>();
        canonShoot = FindObjectOfType<CanonShoot>();
        rotatingPlanet = FindObjectOfType<RotatingPlanet>();
        planet = FindObjectOfType<FauxGravityAttractor>().gameObject.transform;
        playerPositionOfTheMechanic = GameObject.FindGameObjectWithTag("PlanetRotateChild").transform;
    }

    private void Start()
    {
        mechanicState = MechanicState.Player;
    }

    private void Update()
    {
        if (rotateEnabled)
            RotatePlanet();

        if(Input.GetButtonDown("EnterExit_P1"))
        {
            if (mechanicTypeInCollider == "canon" && !hasEntered)
            {
                playeController.playerMovementEnabled = false;
                //playeController.transform.position = canonShoot.playerPositionOfTheMechanic.position;

                canonShoot.EnableCanon(true, true);
                // enable canon
                hasEntered = true;
                mechanicState = MechanicState.Canon;
            }
            else if (mechanicTypeInCollider == "PlanetRotator" && !hasEntered)
            {
                playeController.playerMovementEnabled = false;
                //playeController.transform.position = rotatingPlanet.playerPositionOfTheMechanic.position;

                rotateEnabled = true;

                mechanicState = MechanicState.PlanetRotate;
                hasEntered = true;
            }
            else if (hasEntered)
            {
                canonShoot.EnableCanon(false, true);
                rotateEnabled = false;

                playeController.playerMovementEnabled = true;

                mechanicState = MechanicState.Player;
                hasEntered = false;
            }
        }
        else if (Input.GetButtonDown("EnterExit_P2"))
        {
            if (mechanicTypeInCollider == "canon" && !hasEntered)
            {
                playeController.playerMovementEnabled = false;
                //playeController.transform.position = canonShoot.playerPositionOfTheMechanic.position;

                canonShoot.EnableCanon(true, false);
                // enable canon
                hasEntered = true;
                mechanicState = MechanicState.Canon;
            }
            else if (mechanicTypeInCollider == "PlanetRotator" && !hasEntered)
            {
                playeController.playerMovementEnabled = false;
                //playeController.transform.position = rotatingPlanet.playerPositionOfTheMechanic.position;

                rotateEnabled = true;

                mechanicState = MechanicState.PlanetRotate;
                hasEntered = true;
            }
            else if (hasEntered)
            {
                canonShoot.EnableCanon(false, false);
                rotateEnabled = false;

                playeController.playerMovementEnabled = true;

                mechanicState = MechanicState.Player;
                hasEntered = false;
            }
        }
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
