using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject[] OtherObjects;
    public float delay = 2f;
    public float[] spawnRates;
    public int numObjectsToPool = 5;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private GameObject currentSpawnedObject; // Reference to the currently spawned object

    private bool isObjectsActive = true;

    private void OnEnable()
    {
        GameClock.OnTimeReached += DestroySpawnedObjects;
    }

    private void OnDisable()
    {
        GameClock.OnTimeReached -= DestroySpawnedObjects;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleObjectsActive(!isObjectsActive);
        }
    }

    public void SpawnObject()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    IEnumerator SpawnObjectWithDelay()
    {
        // Spawn ObjectToSpawn and destroy it after delay
        GameObject obj = Instantiate(ObjectToSpawn, transform.position, transform.rotation);
        currentSpawnedObject = obj; // Store reference to the spawned object
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
            objectToSpawn = OtherObjects[0];
        }

        // Spawn the chosen object
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedObjects.Add(spawnedObject);
        spawnedObject.SetActive(isObjectsActive); // Set initial active state
    }

    private void DestroySpawnedObjects()
    {
        // Destroy the currently spawned object (interrupt animation)
        if (currentSpawnedObject != null)
        {
            Destroy(currentSpawnedObject);
        }

        // Destroy all other spawned objects
        foreach (GameObject spawnedObject in spawnedObjects)
        {
            Destroy(spawnedObject);
        }

        // Clear the list of spawned objects
        spawnedObjects.Clear();
    }

    private void ToggleObjectsActive(bool active)
    {
        isObjectsActive = active;

        // Create a new list to store the valid spawned objects
        List<GameObject> validSpawnedObjects = new List<GameObject>();

        foreach (GameObject spawnedObject in spawnedObjects)
        {
            if (spawnedObject != null) // Check if the GameObject is not null (not destroyed)
            {
                spawnedObject.SetActive(active);
                validSpawnedObjects.Add(spawnedObject);
            }
        }

        spawnedObjects = validSpawnedObjects; // Update the spawnedObjects list with valid objects
    }

    public void UpdateSpawnedObjectsList(GameObject objectToRemove)
    {
        spawnedObjects.Remove(objectToRemove);
    }
}