using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUspawner : MonoBehaviour
{
    public float spawnTimer; 
    public GameObject[] powerUps;
    public Transform[] spawnPoints;



    private void Start()
    {
        StartCoroutine(spawnOnDelay());



    }

    IEnumerator spawnOnDelay()
    {
        yield return new WaitForSeconds(spawnTimer);

        Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        StartCoroutine(spawnOnDelay());
    }






}
