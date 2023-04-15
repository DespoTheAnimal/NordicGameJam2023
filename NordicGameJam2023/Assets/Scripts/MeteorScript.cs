using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    [SerializeField] GameObject _spherePrefab;
    [SerializeField] GameObject _planet;
    private float timer = 5f;
    private int id = 0;
    GameObject instantiatedAsteroid;

    public List<GameObject> instantiatedAsteroids = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnSphereOnEdgeRandomly3D();
            timer = 2;
        }
        MoveAsteroids();

    }
    private void SpawnSphereOnEdgeRandomly3D()
    {
        float radius = 10f;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.z = 0f;

        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.up, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.up.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;

        instantiatedAsteroid = Instantiate(_spherePrefab, randomPos, Quaternion.identity);
        instantiatedAsteroid.name = "Asteroid " + id;
        id++;
        instantiatedAsteroids.Add(instantiatedAsteroid);
    }

    public void RemoveAsteroid(string name)
    {
        foreach (GameObject ass in instantiatedAsteroids.ToList())
        {
            if(ass.name == name)
            {
                instantiatedAsteroids.Remove(ass);
                Destroy(ass);
            }
        }
    }


    void MoveAsteroids()
    {   
        if (instantiatedAsteroids.Count > 0)
        {
            foreach (GameObject ass in instantiatedAsteroids)
            {
                Vector3 newPosition = Vector3.MoveTowards(ass.transform.position, _planet.transform.position, 2f * Time.deltaTime);
                ass.transform.position = newPosition;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            RemoveAsteroid(collision.gameObject.name);
        }
    }
}
