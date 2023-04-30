using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && Input.GetKey(KeyCode.E)) // Check if the "E" key is being held down
        {
            player.Bottle++;
            Destroy(gameObject);
        }
    }
}