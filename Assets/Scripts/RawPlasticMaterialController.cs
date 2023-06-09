using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawPlasticMaterialController : MonoBehaviour
{
    private bool isInteractable = true; // Flag to track if the object is interactable
    private MovingObjectTracker objectTracker; // Reference to the ObjectTracker script

    private void Start()
    {
        objectTracker = FindObjectOfType<MovingObjectTracker>(); // Find the ObjectTracker component in the scene
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && isInteractable && Input.GetKey(KeyCode.E)) // Check if the "E" key is being held down and the object is interactable
        {
            if (player.RawPlasticMaterial == 0) // Check if the player does not have any RawPlasticMaterial
            {
                player.RawPlasticMaterial++;

                if (objectTracker != null)
                {
                    objectTracker.RemoveObject(gameObject); // Remove the object from the ObjectTracker
                }

                DestroyObject();
            }
            else
            {
                isInteractable = false; // Set the object as uninteractable
                StartCoroutine(ResetInteractableFlag()); // Start coroutine to reset the flag after a delay
            }
        }
    }

    private IEnumerator ResetInteractableFlag()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed
        isInteractable = true; // Reset the flag to allow interaction
    }

    private void DestroyObject()
    {
        // Additional logic for destroying the game object, if needed
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (objectTracker != null)
        {
            objectTracker.RemoveObject(gameObject); // Remove the object from the ObjectTracker when it is destroyed
        }
    }
}