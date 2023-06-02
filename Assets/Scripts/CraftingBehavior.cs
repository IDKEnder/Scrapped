using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBehavior : MonoBehaviour
{
    public Spawner spawner;
    public CraftOrMelt craftOrMelt;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && Input.GetKey(KeyCode.E))
        {
            switch (craftOrMelt)
            {
                case CraftOrMelt.Craft:
                    Craft(player);
                    break;
                case CraftOrMelt.Melt:
                    Melt(player);
                    break;
                default:
                    Debug.LogError("Invalid CraftOrMelt option");
                    break;
            }
        }
    }

    private void Craft(Player player)
    {
        if (player.RawPlasticMaterial >= 1)
        {
            player.RawPlasticMaterial--;
            spawner.SpawnObject();
        }
    }

    private void Melt(Player player)
    {
        if (player.RawMetal >= 1)
        {
            player.RawMetal--;
            spawner.SpawnObject();
        }
    }
}

public enum CraftOrMelt
{
    Craft,
    Melt
}