using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottles : MonoBehaviour
{
    [SerializeField]
    private int num = 1; // Default value of num is 1

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && Input.GetKey(KeyCode.E)) // Check if the "E" key is being held down
        {
            switch (num)
            {
                case 1:
                    player.Bottle++;
                    break;
                case 2:
                    player.DoubleBottle++;
                    break;
                case 3:
                    player.TripleBottle++;
                    break;
                case 4:
                    player.GoldenBottle++;
                    break;
                case 5:
                    player.BrokenBottle++;
                    break;
                default:
                    Debug.LogError("Invalid num value");
                    break;
            }

            Destroy(gameObject);
        }
    }
}