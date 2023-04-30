using UnityEngine;
using UnityEngine.UI;

public class DisplayShipment : MonoBehaviour
{
    public Shipment shipment;
    public Text displayText;
    public float bottlePrice = 1f;
    public float doubleBottlePrice = 2f;
    public float tripleBottlePrice = 3f;
    public float goldenBottlePrice = 5f;
    public float brokenBottlePrice = 0.5f;
    public float rawPlasticMaterialPrice = 0.1f;

    private void Update()
    {
        string displayString = "";
        float total = 0f;

        float bottleTotal = shipment.Bottle * bottlePrice;
        total += bottleTotal;
        displayString += "Bottle: " + shipment.Bottle + "  --  Price: $" + bottlePrice.ToString("F2") +
            "  --  Total: $" + bottleTotal.ToString("F2") + "\n";

        float doubleBottleTotal = shipment.DoubleBottle * doubleBottlePrice;
        total += doubleBottleTotal;
        displayString += "Double Bottle: " + shipment.DoubleBottle + "  --  Price: $" + doubleBottlePrice.ToString("F2") +
            "  --  Total: $" + doubleBottleTotal.ToString("F2") + "\n";

        float tripleBottleTotal = shipment.TripleBottle * tripleBottlePrice;
        total += tripleBottleTotal;
        displayString += "Triple Bottle: " + shipment.TripleBottle + "  --  Price: $" + tripleBottlePrice.ToString("F2") +
            "  --  Total: $" + tripleBottleTotal.ToString("F2") + "\n";

        float goldenBottleTotal = shipment.GoldenBottle * goldenBottlePrice;
        total += goldenBottleTotal;
        displayString += "Golden Bottle: " + shipment.GoldenBottle + "  --  Price: $" + goldenBottlePrice.ToString("F2") +
            "  --  Total: $" + goldenBottleTotal.ToString("F2") + "\n";

        float brokenBottleTotal = shipment.BrokenBottle * brokenBottlePrice;
        total += brokenBottleTotal;
        displayString += "Broken Bottle: " + shipment.BrokenBottle + "  --  Price: $" + brokenBottlePrice.ToString("F2") +
            "  --  Total: $" + brokenBottleTotal.ToString("F2") + "\n";

        float rawPlasticMaterialTotal = shipment.RawPlasticMaterial * rawPlasticMaterialPrice;
        total += rawPlasticMaterialTotal;
        displayString += "Raw Plastic Material: " + shipment.RawPlasticMaterial + "  --  Price: $" + rawPlasticMaterialPrice.ToString("F2") +
            "  --  Total: $" + rawPlasticMaterialTotal.ToString("F2") + "\n";

        displayString += "Total: $" + total.ToString("F2");

        displayText.text = displayString;

        // Resize and center the text element
        displayText.rectTransform.sizeDelta = new Vector2(1000f, 600f);
        displayText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        displayText.alignment = TextAnchor.MiddleCenter;
    }
}