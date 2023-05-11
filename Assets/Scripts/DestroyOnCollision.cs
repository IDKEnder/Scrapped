using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int DestroyedMaterial = 0; // Variable to store the destroyed material value

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RawMaterialBehavior movingObject = collision.GetComponent<RawMaterialBehavior>();
        if (movingObject != null && movingObject.CanMove())
        {
            Destroy(movingObject.gameObject); 
            DestroyedMaterial--;
            Debug.Log("Moving object destroyed. Destroyed Material: " + DestroyedMaterial); //Checker
        }
    }
}
