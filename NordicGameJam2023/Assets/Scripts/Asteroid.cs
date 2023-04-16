using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private MeteorScript meteorScript;
    public CameraShake cameraShake;

    public float assSpeed = 2;


    private void Start()
    {
        meteorScript = FindObjectOfType<MeteorScript>();
        cameraShake = FindObjectOfType<CameraShake>();
    }


    private void Update()
    {
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, meteorScript.transform.position, 2f * Time.deltaTime);
       
        if(Input.GetKeyDown(KeyCode.H))
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, meteorScript.transform.position, assSpeed * Time.deltaTime * -1);
            transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, meteorScript.transform.position, assSpeed * Time.deltaTime);
            transform.position = newPosition;
        }


        //transform.position = newPosition;
    }

    [SerializeField] private GameObject shieldCollision;
    [SerializeField] private GameObject cannonCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannonball")
        {
            cameraShake.ShakeItUp();
            GameObject clone = Instantiate(cannonCollision, transform.position, transform.rotation);
            meteorScript.RemoveAsteroid(this.name);
        }
        else if (collision.gameObject.tag == "Shield")
        {
            cameraShake.ShakeItUp();
            GameObject clone = Instantiate(shieldCollision, transform.position, transform.rotation);
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;

            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;

            print(dir);

            float force = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            // And finally we add force in the direction of dir and multiply it by force. 
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
