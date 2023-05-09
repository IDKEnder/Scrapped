using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialBehavior : MonoBehaviour
{
    public float MoveSpeed = 2f; // Adjust the move speed as desired

    private Rigidbody2D rb; // Reference to the Rigidbody component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the reference to the Rigidbody component
        rb.velocity = new Vector2(MoveSpeed, 0f); // Set initial velocity
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rb.velocity = Vector2.zero; // Stop the object when it collides with an obstacle
        }

        RawMaterialController otherObject = collision.GetComponent<RawMaterialController>();
        if (otherObject != null)
        {
            rb.velocity = Vector2.zero; // Stop the object when it collides with another moving object
        }
    }
}
