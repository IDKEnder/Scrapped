using UnityEngine;

public class RawMaterialSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // Prefab of the object to spawn
    public float spawnFrequency = 1f; // Frequency of spawning (in seconds)
    public int spawnLimit = 10;       // Maximum number of objects to spawn

    private int spawnCount = 0;       // Counter for spawned objects
    private float timer = 0f;         // Timer for tracking spawn frequency

    private void Update()
    {
        // Check if the spawn count has reached the limit
        if (spawnCount >= spawnLimit)
            return;

        // Increment the timer
        timer += Time.deltaTime;

        // Check if the timer has reached the desired spawn frequency
        if (timer >= spawnFrequency)
        {
            // Spawn the object
            Instantiate(objectToSpawn, transform.position, transform.rotation);

            // Reset the timer
            timer = 0f;

            // Increment the spawn count
            spawnCount++;
        }
    }
}