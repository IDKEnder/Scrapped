using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialBehavior : MonoBehaviour
{
    public float MoveSpeed = 1f; // Adjust the move speed as desired
    public float moveDelay = 1f; // Time delay between movements
    private Rigidbody2D rb; // Reference to the Rigidbody component
    private bool canMove = true; // Flag to check if the object can move

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the reference to the Rigidbody component
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (canMove)
            {
                rb.velocity = new Vector2(MoveSpeed, 0f); // Set initial velocity
                canMove = false; // Set the flag to false before checking for obstacles

                yield return new WaitForSeconds(moveDelay);

                rb.velocity = Vector2.zero; // Stop the object

                yield return new WaitForSeconds(moveDelay);

                canMove = true; // Set the flag to true to allow movement again
            }
            else
            {
                yield return null; // Wait for the next frame if the object cannot move
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rb.velocity = Vector2.zero; // Stop the object when it collides with an obstacle
            canMove = true; // Set the flag to true to allow movement again
        }

        RawMaterialBehavior otherObject = collision.GetComponent<RawMaterialBehavior>();
        if (otherObject != null && !otherObject.CanMove())
        {
            rb.velocity = Vector2.zero; // Stop the object when it collides with another non-moving object
            canMove = true; // Set the flag to true to allow movement again
        }
    }

    public bool CanMove()
    {
        return canMove;
    }
}