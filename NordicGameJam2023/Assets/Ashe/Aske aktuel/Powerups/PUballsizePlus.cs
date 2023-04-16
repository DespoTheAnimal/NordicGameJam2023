using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUballsizePlus : MonoBehaviour
{

    public float multiplier = 2.5f;

    public GameObject pickupEffect;

    public GameObject Bolder_Player1;
    public GameObject Bolder_Player2;

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

        Bolder_Player1 = GameObject.Find("Bolder_Player1");

        Bolder_Player1.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);

        Bolder_Player1.transform.localScale /= multiplier;

        

        Destroy(gameObject);

    }
    IEnumerator Pickup2(Collider other)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        Bolder_Player2 = GameObject.Find("Bolder_Player2");

        Bolder_Player2.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(timer);

        Bolder_Player2.transform.localScale /= multiplier;

     

        Destroy(gameObject);

    }




}
