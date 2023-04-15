using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    string mechanicTypeInCollider;

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
    }



    private void Update()
    {
        if(canEnter)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                if(mechanicTypeInCollider == "canon")
                {
                    Debug.Log("canon");
                    playeController.playerMovementEnabled = false;
                    playeController.transform.position = canonShoot.playerPositionOfTheMechanic.position;

                    canonShoot.EnableCanon(true);
                    // enable canon

                    mechanicState = MechanicState.Canon;
                }
                else if(mechanicTypeInCollider == "PlanetRotator")
                {
                    Debug.Log("PlanetRotator");
                    playeController.playerMovementEnabled = false;
                    playeController.transform.position = rotatingPlanet.playerPositionOfTheMechanic.position;

                    rotatingPlanet.rotateEnabled = true;

                    mechanicState = MechanicState.PlanetRotate;
                }
            }
        }


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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Mechanic")
        {
            canEnter = true;

            if (other.name == "canon")
            {
                mechanicTypeInCollider = "canon";
            }
            else if(other.name == "PlanetRotator")
            {
                mechanicTypeInCollider = "PlanetRotator";
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
