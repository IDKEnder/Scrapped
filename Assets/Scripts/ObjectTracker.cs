using UnityEngine;
using System.Collections.Generic;

public class ObjectTracker : MonoBehaviour
{
    public List<GameObject> spawnedObjects = new List<GameObject>();

    public bool isObjectsActive = true;

    public void AddSpawnedObject(GameObject obj)
    {
        spawnedObjects.Add(obj);
    }

    public void RemoveSpawnedObject(GameObject obj)
    {
        spawnedObjects.Remove(obj);
    }

    public void ToggleObjectsActive(bool active)
    {
        isObjectsActive = active;

        foreach (GameObject obj in spawnedObjects)
        {
            obj.SetActive(active);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleObjectsActive(!isObjectsActive);
        }
    }
}