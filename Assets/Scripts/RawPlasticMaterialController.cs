using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawPlasticMaterialController : MonoBehaviour
{
    private bool isInteractable = true; // Flag to track if the object is interactable

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && isInteractable && Input.GetKey(KeyCode.E)) // Check if the "E" key is being held down and the object is interactable
        {
            if (player.RawPlasticMaterial == 0) // Check if the player does not have any RawPlasticMaterial
            {
                player.RawPlasticMaterial++;
                Destroy(gameObject);
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
}