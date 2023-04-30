using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBehavior : MonoBehaviour
{
    public Spawner spawner;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && player.RawPlasticMaterial >= 1 && Input.GetKey(KeyCode.E))
        {
            player.RawPlasticMaterial--;
            spawner.SpawnObject();
        }
    }
}