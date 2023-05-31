using UnityEngine;
using System.Collections.Generic;

public class MovingObjectTracker : MonoBehaviour
{
    private List<GameObject> instantiatedObjects = new List<GameObject>();

    private bool isObjectsActive = true;

    public void AddObject(GameObject obj)
    {
        instantiatedObjects.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {
        instantiatedObjects.Remove(obj);
    }

    public List<GameObject> GetObjects()
    {
        return instantiatedObjects;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isObjectsActive = !isObjectsActive;

            foreach (GameObject obj in instantiatedObjects)
            {
                if (isObjectsActive)
                {
                    obj.SetActive(true);

                    if (obj.GetComponent<RawMaterialBehavior>() == null)
                    {
                        obj.AddComponent<RawMaterialBehavior>();
                    }

                    RawMaterialBehavior rawMaterialBehavior = obj.GetComponent<RawMaterialBehavior>();
                    Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                    rb.WakeUp();
                    rb.velocity = new Vector2(rawMaterialBehavior.MoveSpeed, 0f);
                }
                else
                {
                    obj.SetActive(false);

                    RawMaterialBehavior rawMaterialBehavior = obj.GetComponent<RawMaterialBehavior>();
                    if (rawMaterialBehavior != null)
                    {
                        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                        rb.Sleep();
                        rb.velocity = Vector2.zero;
                        Destroy(rawMaterialBehavior);
                    }
                }
            }
        }
    }
}
