using UnityEngine;

public class RawMaterialSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnFrequency = 1f;
    public int spawnLimit = 10;
    private int spawnCount = 0;
    private float timer = 0f;

    private void OnEnable()
    {
        GameClock.OnTimeThresholdReached += DestroyAllSpawnedObjects;
    }

    private void OnDisable()
    {
        GameClock.OnTimeThresholdReached -= DestroyAllSpawnedObjects;
    }

    private void Update()
    {
        // Check if the spawn count has reached the limit
        if (spawnCount >= spawnLimit)
            return;

        timer += Time.deltaTime;

        // Check if the timer has reached the desired spawn frequency
        if (timer >= spawnFrequency)
        {
            // Spawn the object
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

            // Attach the RawMaterialBehavior script to the spawned object
            RawMaterialBehavior rawMaterialBehavior = spawnedObject.AddComponent<RawMaterialBehavior>();

            // Reset the timer
            timer = 0f;

            // Increment the spawn count
            spawnCount++;
        }
    }

    private void DestroyAllSpawnedObjects()
    {
        // Find all GameObjects with the RawMaterialBehavior script attached
        RawMaterialBehavior[] rawMaterialBehaviors = FindObjectsOfType<RawMaterialBehavior>();

        // Destroy each spawned object
        foreach (RawMaterialBehavior rawMaterialBehavior in rawMaterialBehaviors)
        {
            Destroy(rawMaterialBehavior.gameObject);
        }

        // Reset the spawn count
        spawnCount = 0;

    }
}