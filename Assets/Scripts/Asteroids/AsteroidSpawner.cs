
using System.Collections;
using UnityEngine;

public class AsteroidSpawner : Spawner
{

    public Transform asteroidSpawnPoint;

    public GameObject asteroidPrefab;

    public float spawnInterval;

    public float spawnDelay;

    public float minX;

    public float maxX;

    public float fixedY;


    public override void Spawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        // Loop runs continuously in the background
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, fixedY, 0f);

            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public override void Start()
    {
        Spawn();
    }

    public override void Update()
    {
        
    }

}
