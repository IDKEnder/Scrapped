using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int DestroyedMaterial = 0; // Variable to store the destroyed material value
    private MovingObjectTracker ObjectTracker; // Reference to the ObjectTracker script

    private void Start()
    {
        ObjectTracker = FindObjectOfType<MovingObjectTracker>(); // Find the ObjectTracker component in the scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RawMaterialBehavior movingObject = collision.GetComponent<RawMaterialBehavior>();
        if (movingObject != null && movingObject.CanMove())
        {
            Destroy(movingObject.gameObject);
            DestroyedMaterial--;
            Debug.Log("Moving object destroyed. Destroyed Material: " + DestroyedMaterial); //Checker

            if (ObjectTracker != null)
            {
                ObjectTracker.RemoveObject(movingObject.gameObject); // Remove the destroyed object from the ObjectTracker
            }
        }
    }
}