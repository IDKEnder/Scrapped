using UnityEngine;

public class UISpawner : MonoBehaviour
{
    public enum MaterialType
    {
        RawPlasticMaterial,
        RawMetalMaterial
    }

    public MaterialType selectedMaterial;
    public GameObject item; // The item game object to spawn
    private GameObject spawnedItem; // Reference to the spawned item
    public Player player; // Reference to the Player script
    public ObjectTracker objectTracker; // Reference to the ObjectTracker script

    private void Update()
    {
        if (player != null)
        {
            if (HasMaterialType(selectedMaterial))
            {
                if (spawnedItem == null)
                {
                    SpawnItem();
                }
            }
            else if (spawnedItem != null)
            {
                DestroyItem();
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
        spawnedItem = Instantiate(item, transform.position, transform.rotation);

        // Add the spawned item to the ObjectTracker
        objectTracker.AddSpawnedObject(spawnedItem);
    }

    private void DestroyItem()
    {
        // Remove the spawned item from the ObjectTracker
        objectTracker.RemoveSpawnedObject(spawnedItem);

        // Destroy the spawned item
        Destroy(spawnedItem);
        spawnedItem = null;
    }
}
