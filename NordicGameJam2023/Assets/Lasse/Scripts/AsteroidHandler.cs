using UnityEngine;
public class AsteroidHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] AsteroidPrefabs;

    [SerializeField] private int areaMin, areaMax;
    [SerializeField] private int amountOfObjectsToSpawn = 100;

    void Start()
    {
        SpawnAsteroids(amountOfObjectsToSpawn);
    }

    private void SpawnAsteroids(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var pos = new Vector3(Random.Range(areaMin, areaMax), Random.Range(areaMin, areaMax), 0);
            var chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            var asteroid = Instantiate(chosenAsteroid, pos, Quaternion.identity);

            // You can still manipulate asteroid afterwards like .AddComponent etc
        }
    }
}