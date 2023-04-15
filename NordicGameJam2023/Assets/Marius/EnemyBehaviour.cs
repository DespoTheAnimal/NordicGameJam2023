using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float force;
    public float enemySpeed;

    public GameObject target;


    void OnCollisionEnter(Collision c)
    {
        // If the object we hit is the enemy
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
        else if(c.gameObject.tag == "Player")
        {
            //Lose life or something
        }
    }


    private void FollowTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed);
    }
}
