using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private MeteorScript meteorScript;

    private void Start()
    {
        meteorScript = FindObjectOfType<MeteorScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannonball")
        {
            meteorScript.RemoveAsteroid(this.name);
        }
    }
}
