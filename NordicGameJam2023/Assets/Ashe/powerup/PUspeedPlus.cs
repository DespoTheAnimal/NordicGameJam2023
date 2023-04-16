using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUspeedPlus : MonoBehaviour
{
    public float multiplier = 3f;
    public float originalSpeed = 10.0f;

    public GameObject pickupEffect;

    public GameObject Player;
    public GameObject Player2;

    public int timer = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            StartCoroutine(Pickup(other));
        }

        else if (other.CompareTag("Player2"))

        {
            StartCoroutine(Pickup2(other));
        }


    }


    IEnumerator Pickup(Collider other)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        GameObject Player = GameObject.Find("Player1");

        Controls controls = Player.GetComponent<Controls>();
        controls.moveSpeed += 5f;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);


        controls.moveSpeed = originalSpeed;


        Destroy(gameObject);

    }
    IEnumerator Pickup2(Collider other)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        GameObject Player2 = GameObject.Find("Player2");

        Controls controls = Player2.GetComponent<Controls>();
        controls.moveSpeed += 5f;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);


        controls.moveSpeed = originalSpeed;


        Destroy(gameObject);

    }


}
