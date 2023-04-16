using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUspeedMinus : MonoBehaviour
{


    public float multiplier = 3f;
    public int originalSpeed = 10;

    public GameObject pickupEffect;

    public GameObject Player;
    public GameObject Player2;

    public int timer = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))

        {
            StartCoroutine(Pickup(other));
        }

        else if (other.CompareTag("Player"))

        {
            StartCoroutine(Pickup2(other));
        }


    }


    IEnumerator Pickup(Collider other)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        GameObject Player = GameObject.Find("Player2");

        PlayerController controls = Player.GetComponent<PlayerController>();
        controls.speedModifier -= 5;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);


        controls.speedModifier = originalSpeed;


        Destroy(gameObject);

    }
    IEnumerator Pickup2(Collider other)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        GameObject Player2 = GameObject.Find("Player1");

        PlayerController controls = Player2.GetComponent<PlayerController>();
        controls.speedModifier -= 5;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);


        controls.speedModifier = originalSpeed;


        Destroy(gameObject);

    }


}
