using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float speed;
    public GameObject enemy;



    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        enemy.GetComponent<Rigidbody>().AddForce(new Vector3(0, -speed, 0), ForceMode.Impulse);
    }
}
