using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnterAndExitMechanic : MonoBehaviour
{
    public enum MechanicState { 
        Player, 
        Canon,
        PlanetRotate,
    }

    public MechanicState mechanicState;

    PlayerController playeController;
    CanonShoot canonShoot;
    RotatingPlanet rotatingPlanet;

    private GameInput gameInput;

    string mechanicTypeInCollider;

    bool hasEntered = false;

    [SerializeField] private bool canEnter = false;

    private void Awake()
    {
        playeController = FindObjectOfType<PlayerController>();
        canonShoot = FindObjectOfType<CanonShoot>();
        rotatingPlanet = FindObjectOfType<RotatingPlanet>();
    }

    private void Start()
    {
        mechanicState = MechanicState.Player;
        gameInput = FindObjectOfType<GameInput>();
        gameInput.PlayerInput.Controls.EnterExit.performed += EnterExit_performed;
    }

    bool test;

    public void EnterExit_performed(InputAction.CallbackContext ctx)
    {
        test = ctx.ReadValueAsButton();
       
        if(test)
        {
            if (canEnter)
            {
                if (mechanicTypeInCollider == "canon" && !hasEntered)
                {
                    Debug.Log("canon");
                    playeController.playerMovementEnabled = false;
                    playeController.transform.position = canonShoot.playerPositionOfTheMechanic.position;

                    canonShoot.EnableCanon(true);
                    // enable canon
                    hasEntered = true;
                    mechanicState = MechanicState.Canon;
                }
                else if (mechanicTypeInCollider == "PlanetRotator" && !hasEntered)
                {
                    Debug.Log("PlanetRotator");
                    playeController.playerMovementEnabled = false;
                    playeController.transform.position = rotatingPlanet.playerPositionOfTheMechanic.position;

                    rotatingPlanet.rotateEnabled = true;

                    mechanicState = MechanicState.PlanetRotate;
                    hasEntered = true;
                }
                else if (hasEntered)
                {
                    canonShoot.EnableCanon(false);
                    rotatingPlanet.rotateEnabled = false;

                    playeController.playerMovementEnabled = true;

                    mechanicState = MechanicState.Player;
                    hasEntered = false;
                }

            }
        }
        
    }


    private void Update()
    {
        if(mechanicState == MechanicState.Canon || mechanicState == MechanicState.PlanetRotate)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                canonShoot.EnableCanon(false);
                rotatingPlanet.rotateEnabled = false;

                playeController.playerMovementEnabled = true;

                mechanicState = MechanicState.Player;
            }
        }
    }

    private GameObject OnTriggerStay(Collider other)
    {
        if (other.tag == "Mechanic")
        {
            canEnter = true;

            if (other.name == "canon")
            {
                mechanicTypeInCollider = "canon";
                return gameObject;
            }
            else if(other.name == "PlanetRotator")
            {
                mechanicTypeInCollider = "PlanetRotator";
                return gameObject;
            }
        }
        else
        {
            canEnter = false;
            mechanicTypeInCollider = "";
            return null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canEnter = false;
        mechanicTypeInCollider = "";
    }
}
