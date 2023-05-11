using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    float lastTime;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Calculate time elapsed since last FixedUpdate
        float timeElapsed = Time.fixedDeltaTime;

        // Calculate movement with time-based speed
        Vector2 velocity = movement.normalized * moveSpeed * timeElapsed;

        // Move the rigidbody
        rb.MovePosition(rb.position + velocity);
    }
}