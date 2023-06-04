using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    private Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        if (spawner == null)
        {
            Debug.LogError("Spawner component not found.");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && Input.GetKey(KeyCode.E)) // Check if the "E" key is being held down
        {
            Destroy(gameObject);
            switch (itemType)
            {
                case ItemType.Bottle:
                    player.Bottle++;
                    break;
                case ItemType.DoubleBottle:
                    player.DoubleBottle++;
                    break;
                case ItemType.TripleBottle:
                    player.TripleBottle++;
                    break;
                case ItemType.GoldenBottle:
                    player.GoldenBottle++;
                    break;
                case ItemType.BrokenBottle:
                    player.BrokenBottle++;
                    break;
                case ItemType.Can:
                    player.Can++;
                    break;
                case ItemType.DoubleCan:
                    player.DoubleCan++;
                    break;
                case ItemType.TripleCan:
                    player.TripleCan++;
                    break;
                case ItemType.GoldenCan:
                    player.GoldenCan++;
                    break;
                case ItemType.BrokenCan:
                    player.BrokenCan++;
                    break;
                default:
                    Debug.LogError("Invalid item type");
                    break;
            }

            if (spawner != null)
            {
                spawner.UpdateSpawnedObjectsList(gameObject);
            }
        }
    }
}

public enum ItemType
{
    Bottle,
    DoubleBottle,
    TripleBottle,
    GoldenBottle,
    BrokenBottle,
    Can,
    DoubleCan,
    TripleCan,
    GoldenCan,
    BrokenCan
}