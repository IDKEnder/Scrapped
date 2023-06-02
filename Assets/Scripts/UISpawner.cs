using UnityEngine;
using System.Collections.Generic;

public class UISpawner : MonoBehaviour
{
    public enum MaterialType
    {
        RawPlasticMaterial,
        RawMetalMaterial
    }

    public MaterialType selectedMaterial;
    public GameObject item; // The item game object to spawn
    private List<GameObject> spawnedItems = new List<GameObject>(); // List to store spawned items for this instance
    public Player player; // Reference to the Player script
    public ObjectTracker objectTracker; // Reference to the ObjectTracker script
    public GameClock gameClock; // Reference to the GameClock script

    private void OnEnable()
    {
        GameClock.OnTimeReached += DestroySpawnedItems;
    }

    private void OnDisable()
    {
        GameClock.OnTimeReached -= DestroySpawnedItems;
    }

    private void Update()
    {
        if (player != null)
        {
            if (HasMaterialType(selectedMaterial))
            {
                if (spawnedItems.Count == 0)
                {
                    SpawnItem();
                }
            }
            else if (spawnedItems.Count > 0)
            {
                DestroyItems();
            }
        }
    }

    private bool HasMaterialType(MaterialType materialType)
    {
        switch (materialType)
        {
            case MaterialType.RawPlasticMaterial:
                return player.RawPlasticMaterial == 1;
            case MaterialType.RawMetalMaterial:
                return player.RawMetal == 1;
            default:
                return false;
        }
    }

    private void SpawnItem()
    {
        // Instantiate a new game object as the item
        GameObject newSpawnedItem = Instantiate(item, transform.position, transform.rotation);

        // Add the spawned item to the ObjectTracker
        objectTracker.AddSpawnedObject(newSpawnedItem);

        // Add the spawned item to the list
        spawnedItems.Add(newSpawnedItem);
    }

    private void DestroyItems()
    {
        foreach (GameObject spawnedItem in spawnedItems)
        {
            // Remove the spawned item from the ObjectTracker
            objectTracker.RemoveSpawnedObject(spawnedItem);

            // Destroy the spawned item
            Destroy(spawnedItem);
        }

        // Clear the list
        spawnedItems.Clear();
    }

    private void DestroySpawnedItems()
    {
        DestroyItems();
    }
}
