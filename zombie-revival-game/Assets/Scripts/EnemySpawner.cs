using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;       // The enemy prefab to spawn
    public Transform spawnPoint;         // Where enemies appear
    public float minSpawnTime = 5f;      // Minimum time between spawns
    public float maxSpawnTime = 10f;     // Maximum time between spawns
    public float riseHeight = 2f;        // How high the enemy rises from the ground
    public float riseSpeed = 2f;         // Speed of rising

    void Start()
    {
        // Start spawning loop
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // Wait a random amount of time before next spawn
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Spawn enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Make it rise from the ground
            StartCoroutine(RiseFromGround(enemy.transform));
        }
    }

    IEnumerator RiseFromGround(Transform enemy)
    {
        Vector3 startPos = enemy.position - new Vector3(0, riseHeight, 0); // underground start
        Vector3 targetPos = enemy.position;

        enemy.position = startPos;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * riseSpeed;
            enemy.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }
        
        enemy.GetComponent<Enemy>().enabled = true;
    }
}