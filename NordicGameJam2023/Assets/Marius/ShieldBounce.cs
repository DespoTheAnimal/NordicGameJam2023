using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SÆTTES PÅ ASTROIDE - SØRG FOR AT SKJOLDET HEDDER "Shield"
public class ShieldBounce : MonoBehaviour
{
    public float force;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Shield")
        {   
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;

            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;

            print(dir);
            // And finally we add force in the direction of dir and multiply it by force. 
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
