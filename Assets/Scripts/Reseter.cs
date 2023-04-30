using UnityEngine;

public class Reseter : MonoBehaviour
{
    public Player playerScript;
    public Shipment shipmentScript;

    public void ResetAllVariables()
    {
        playerScript.Bottle = 0;
        playerScript.DoubleBottle = 0;
        playerScript.TripleBottle = 0;
        playerScript.GoldenBottle = 0;
        playerScript.BrokenBottle = 0;
        playerScript.RawPlasticMaterial = 0;

        shipmentScript.Bottle = 0;
        shipmentScript.DoubleBottle = 0;
        shipmentScript.TripleBottle = 0;
        shipmentScript.GoldenBottle = 0;
        shipmentScript.BrokenBottle = 0;
        shipmentScript.RawPlasticMaterial = 0;
    }
}