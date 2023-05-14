using UnityEngine;
using UnityEngine.UI;

public class DisplayShipment : MonoBehaviour
{
    public DestroyOnCollision destroyOnCollision;
    public Shipment shipment;
    public Text displayText;
    private float bottlePrice = 1f;
    private float doubleBottlePrice = 2f;
    private float tripleBottlePrice = 3f;
    private float goldenBottlePrice = 5f;
    private float brokenBottlePrice = 0.5f;
    private float DestroyedMaterialDeduction = -10f;
    public float total = 0f;

    private void Update()
    {
        total = 0f;
        string displayString = "";

        float bottleTotal = shipment.Bottle * bottlePrice;
        displayString += "Bottle: " + shipment.Bottle + "  --  Price: $" + bottlePrice.ToString("F2") +
            "  --  Total: $" + bottleTotal.ToString("F2") + "\n";

        float doubleBottleTotal = shipment.DoubleBottle * doubleBottlePrice;
        displayString += "Double Bottle: " + shipment.DoubleBottle + "  --  Price: $" + doubleBottlePrice.ToString("F2") +
            "  --  Total: $" + doubleBottleTotal.ToString("F2") + "\n";

        float tripleBottleTotal = shipment.TripleBottle * tripleBottlePrice;
        displayString += "Triple Bottle: " + shipment.TripleBottle + "  --  Price: $" + tripleBottlePrice.ToString("F2") +
            "  --  Total: $" + tripleBottleTotal.ToString("F2") + "\n";

        float goldenBottleTotal = shipment.GoldenBottle * goldenBottlePrice;
        displayString += "Golden Bottle: " + shipment.GoldenBottle + "  --  Price: $" + goldenBottlePrice.ToString("F2") +
            "  --  Total: $" + goldenBottleTotal.ToString("F2") + "\n";

        float brokenBottleTotal = shipment.BrokenBottle * brokenBottlePrice;
        displayString += "Broken Bottle: " + shipment.BrokenBottle + "  --  Price: $" + brokenBottlePrice.ToString("F2") +
            "  --  Total: $" + brokenBottleTotal.ToString("F2") + "\n";

        float DestroyedMaterialTotal = destroyOnCollision.DestroyedMaterial * DestroyedMaterialDeduction;
        displayString += "Destroyed Material: " + (destroyOnCollision.DestroyedMaterial * -1) + "  --  Deduction: $" + (DestroyedMaterialDeduction * -1).ToString("F2") +
            "  --  Total: $" + total.ToString("F2") + "\n";

        total = bottleTotal + doubleBottleTotal + tripleBottleTotal + goldenBottleTotal + brokenBottleTotal - DestroyedMaterialTotal;
        displayString += "Total: $" + total.ToString("F2");

        displayText.text = displayString;

        // Resize and center the text element
        displayText.rectTransform.sizeDelta = new Vector2(1000f, 600f);
        displayText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        displayText.alignment = TextAnchor.MiddleCenter;
    }
}