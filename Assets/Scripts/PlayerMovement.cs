using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public AudioSource Foot_Steps;
    public float footstepInterval = 0.05f;
    public float nextFootstepTime;

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

        if (movement.x != 0 || movement.y != 0)
        {
            if (Time.time >= nextFootstepTime)
            {
                Foot_Steps.Play();
                nextFootstepTime = Time.time + footstepInterval;

            }

        }
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