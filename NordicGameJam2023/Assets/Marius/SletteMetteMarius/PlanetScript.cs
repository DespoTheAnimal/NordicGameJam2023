using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float gravity = -12f;

    public void Attract(Transform playerTransfrom)
    {
        Vector3 gravityUp = (playerTransfrom.position - transform.position).normalized;
        Vector3 localUp = playerTransfrom.up;

        playerTransfrom.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransfrom.rotation;
        playerTransfrom.rotation = Quaternion.Slerp(playerTransfrom.rotation, targetRotation, 50f * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
