using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Enemy Spawning")]
    public int enemyCount;
    public float ufoChance;

    [Header("Enemy Prefabs")]
    public GameObject ufoPrefab;
    public GameObject asteroidPrefab;

    [Header("Timed Spawning")]
    public float spawnInterval = 2f;
    public float spawnDelay = 1f;

    // How long enemies are allowed to spawn.
    public float spawningDuration = 30f;

    public override void Start()
    {
        // Spawn the starting group of enemies.
        for (int i = 0; i < enemyCount; i++)
        {
            Spawn();
        }

        // Start the timed spawning.
        StartCoroutine(SpawnCoroutine());
    }

    public override void Spawn()
    {
        if (LevelManager.instance == null)
        {
            return;
        }

        // Pick a random X position across the top.
        float randomX = Random.Range(
            LevelManager.instance.screenLeft,
            LevelManager.instance.screenRight
        );

        // Spawn at the top of the screen.
        float spawnY = LevelManager.instance.screenTop;

        Vector2 randomPosition = new Vector2(randomX, spawnY);

        GameObject prefab;

        float randomChance = Random.Range(0f, 100f);

        // Decide whether this enemy is a UFO or asteroid.
        if (randomChance < ufoChance)
        {
            prefab = ufoPrefab;
        }
        else
        {
            prefab = asteroidPrefab;
        }

        // Spawn the enemy.
        if (prefab != null)
        {
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        // Wait before starting continuous spawning.
        yield return new WaitForSeconds(spawnDelay);

        // Keep track of how long we have been spawning.
        float elapsedTime = 0f;

        // Continue spawning until the time limit is reached.
        while (elapsedTime < spawningDuration)
        {
            Spawn();

            // Wait before spawning another enemy.
            yield return new WaitForSeconds(spawnInterval);

            // Add the time we waited.
            elapsedTime += spawnInterval;
        }

        // Spawning has now stopped.
        Debug.Log("Enemy spawning has finished!");
    }

    public override void Update()
    {
    }
}