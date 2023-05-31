using UnityEngine;

[System.Serializable]
public class SpawnableObject
{
    public GameObject objectPrefab;
    public float spawnChance;
}

public class RawMaterialSpawner : MonoBehaviour
{
    public SpawnableObject[] objectsToSpawn;
    public float spawnFrequency = 1f;
    public int spawnLimit = 10;
    public float spawnDelay = 2f;
    public int spawnCount = 0;
    private float timer = 0f;
    private float delayTimer = 0f;
    public ObjectTracker objectTracker;

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
        if (spawnCount >= spawnLimit)
            return;

        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
            return;
        }

        timer += Time.deltaTime;

        // Check if the timer has reached the desired spawn frequency
        if (timer >= spawnFrequency)
        {
            // Calculate total spawn chance
            float totalSpawnChance = 0f;
            foreach (SpawnableObject spawnableObject in objectsToSpawn)
            {
                totalSpawnChance += spawnableObject.spawnChance;
            }

            // Generate a random value between 0 and the total spawn chance
            float randomValue = Random.Range(0f, totalSpawnChance);

            // Determine which object to spawn based on the random value
            float cumulativeChance = 0f;
            foreach (SpawnableObject spawnableObject in objectsToSpawn)
            {
                cumulativeChance += spawnableObject.spawnChance;
                if (randomValue <= cumulativeChance)
                {
                    GameObject spawnedObject = Instantiate(spawnableObject.objectPrefab, transform.position, transform.rotation);

                    // Attach the RawMaterialBehavior script to the spawned object
                    RawMaterialBehavior rawMaterialBehavior = spawnedObject.AddComponent<RawMaterialBehavior>();

                    // Add the spawned object to the object tracker
                    objectTracker.AddObject(spawnedObject);

                    spawnCount++;

                    break;
                }
            }

            timer = 0f;

            delayTimer = spawnDelay;
        }
    }

    private void DestroyAllSpawnedObjects()
    {
        foreach (GameObject obj in objectTracker.GetObjects())
        {
            Destroy(obj);
        }

        spawnCount = 0;
    }
}