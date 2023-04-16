using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUspeedPlus : MonoBehaviour
{
    public int multiplier = 3;
    public int originalSpeed = 1;

    //public GameObject pickupEffect;

    public PlayerController Player;

    public int timer = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Player = other.GetComponent<PlayerController>();
            StartCoroutine(Pickup(Player));
            Debug.Log("collide");
        }
    }


    IEnumerator Pickup(PlayerController player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);


        player.speedModifier += multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);


        player.speedModifier = originalSpeed;


        Destroy(gameObject);

    }
    //IEnumerator Pickup2(Collider other)
    //{
    //    //Instantiate(pickupEffect, transform.position, transform.rotation);

    //    GameObject Player2 = GameObject.Find("Player 2");

    //    PlayerController controls = Player2.GetComponent<PlayerController>();
    //    controls.speedModifier += 5;

    //    GetComponent<MeshRenderer>().enabled = false;
    //    GetComponent<Collider>().enabled = false;

    //    yield return new WaitForSeconds(timer);


    //    controls.speedModifier = originalSpeed;


    //    Destroy(gameObject);

    //}


}