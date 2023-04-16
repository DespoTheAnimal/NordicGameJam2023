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
    private int asteroidDamage = 20;

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
        //MoveAsteroids();

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

    bool direction;
    private void ChangeDirection()
    {
        direction = !direction;
        GetComponent<RotatingPlanet>().GetValues(direction, 1f);
    }

    [SerializeField] private GameObject asteroidCollisionVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            ChangeDirection();
            GetComponent<Health>().TakeDamage(asteroidDamage);
            GameObject clone = Instantiate(asteroidCollisionVFX, collision.transform.position, Quaternion.identity);
            RemoveAsteroid(collision.gameObject.name);
        }
    }
}
