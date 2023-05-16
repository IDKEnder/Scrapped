using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipment : MonoBehaviour
{
    public int Bottle = 0;
    public int DoubleBottle = 0;
    public int TripleBottle = 0;
    public int GoldenBottle = 0;
    public int BrokenBottle = 0;
    public int Can = 0;
    public int DoubleCan = 0;
    public int TripleCan = 0;
    public int GoldenCan = 0;
    public int BrokenCan = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && Input.GetKey(KeyCode.E))
        {
            if (player.Bottle > 0)
            {
                player.Bottle--;
                Bottle++;
            }
            if (player.DoubleBottle > 0)
            {
                player.DoubleBottle--;
                DoubleBottle++;
            }
            if (player.TripleBottle > 0)
            {
                player.TripleBottle--;
                TripleBottle++;
            }
            if (player.GoldenBottle > 0)
            {
                player.GoldenBottle--;
                GoldenBottle++;
            }
            if (player.BrokenBottle > 0)
            {
                player.BrokenBottle--;
                BrokenBottle++;
            }
            if (player.Can > 0)
            {
                player.Can--;
                Can++;
            }
            if (player.DoubleCan > 0)
            {
                player.DoubleCan--;
                DoubleCan++;
            }
            if (player.TripleCan > 0)
            {
                player.TripleCan--;
                TripleCan++;
            }
            if (player.GoldenCan > 0)
            {
                player.GoldenCan--;
                GoldenCan++;
            }
            if (player.BrokenCan > 0)
            {
                player.BrokenCan--;
                BrokenCan++;
            }
        }
    }
}
