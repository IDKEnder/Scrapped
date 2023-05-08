using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialController : MonoBehaviour
{
    public float MoveSpeed = 5f; // Adjust the move speed as desired

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && Input.GetKey(KeyCode.E)) // Check if the "E" key is being held down
        {
            player.RawPlasticMaterial++;
            Destroy(gameObject);
        }
    }
}