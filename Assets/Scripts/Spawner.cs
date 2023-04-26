using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject[] OtherObjects;
    public float delay = 2f;
    public float[] spawnRates; // The probability of spawning each other object
    public int numObjectsToPool = 5; // The number of objects to pool from

    public void SpawnObject()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    IEnumerator SpawnObjectWithDelay()
    {
        // Spawn ObjectToSpawn and destroy it after delay
        GameObject obj = Instantiate(ObjectToSpawn, transform.position, transform.rotation);
        Destroy(obj, delay);

        yield return new WaitForSeconds(delay);

        // Choose which object to spawn based on spawnRates
        float totalSpawnRate = 0f;
        for (int i = 0; i < spawnRates.Length; i++)
        {
            totalSpawnRate += spawnRates[i];
        }

        float randomValue = Random.Range(0f, totalSpawnRate);

        GameObject objectToSpawn = null;
        for (int i = 0; i < spawnRates.Length; i++)
        {
            randomValue -= spawnRates[i];
            if (randomValue <= 0f)
            {
                objectToSpawn = OtherObjects[i];
                break;
            }
        }

        if (objectToSpawn == null)
        {
            // If ObjectToSpawn is null, default to the first object in the pool
            objectToSpawn = OtherObjects[0];
        }

        // Spawn the chosen object
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}