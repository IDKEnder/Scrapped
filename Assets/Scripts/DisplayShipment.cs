using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayShipment : MonoBehaviour
{
    public DestroyOnCollision destroyOnCollision;
    public Shipment shipment;
    public Text displayText;
    public CashDisplay cashDisplay;
    public Button Nextbutton;
    private float bottlePrice = 100f;
    private float doubleBottlePrice = 200f;
    private float tripleBottlePrice = 300f;
    private float goldenBottlePrice = 500f;
    private float brokenBottlePrice = 50f;
    private float CanPrice = 100f;
    private float doubleCanPrice = 200f;
    private float tripleCanPrice = 300f;
    private float goldenCanPrice = 500f;
    private float brokenCanPrice = 50f;
    private float DestroyedMaterialDeduction = -1000f;
    public float total = 0f;

    private void Start()
    {
        // Add a listener to the button's click event
        Nextbutton.onClick.AddListener(HandleGameOverButtonClick);
    }

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

        float CanTotal = shipment.Can * CanPrice;
        displayString += "Bottle: " + shipment.Bottle + "  --  Price: $" + bottlePrice.ToString("F2") +
            "  --  Total: $" + bottleTotal.ToString("F2") + "\n";

        float doubleCanTotal = shipment.DoubleCan * doubleCanPrice;
        displayString += "Double Bottle: " + shipment.DoubleBottle + "  --  Price: $" + doubleBottlePrice.ToString("F2") +
            "  --  Total: $" + doubleBottleTotal.ToString("F2") + "\n";

        float tripleCanTotal = shipment.TripleCan * tripleCanPrice;
        displayString += "Triple Bottle: " + shipment.TripleBottle + "  --  Price: $" + tripleBottlePrice.ToString("F2") +
            "  --  Total: $" + tripleBottleTotal.ToString("F2") + "\n";

        float goldenCanTotal = shipment.GoldenCan * goldenCanPrice;
        displayString += "Golden Bottle: " + shipment.GoldenBottle + "  --  Price: $" + goldenBottlePrice.ToString("F2") +
            "  --  Total: $" + goldenBottleTotal.ToString("F2") + "\n";

        float brokenCanTotal = shipment.BrokenCan * brokenCanPrice;
        displayString += "Broken Bottle: " + shipment.BrokenBottle + "  --  Price: $" + brokenBottlePrice.ToString("F2") +
            "  --  Total: $" + brokenBottleTotal.ToString("F2") + "\n";

        float DestroyedMaterialTotal = destroyOnCollision.DestroyedMaterial * DestroyedMaterialDeduction;
        displayString += "Destroyed Material: " + (destroyOnCollision.DestroyedMaterial * -1) + "  --  Deduction: $" + (DestroyedMaterialDeduction * -1).ToString("F2") +
            "  --  Total: $" + total.ToString("F2") + "\n";

            displayString += " -1000(Daily Dept)" +"\n";

            total = (bottleTotal + doubleBottleTotal + tripleBottleTotal + goldenBottleTotal + brokenBottleTotal + CanTotal + doubleCanTotal + tripleCanTotal + goldenCanTotal + brokenCanTotal - DestroyedMaterialTotal) - 1000;
            displayString += "Total: $ " + total.ToString("F2");
            displayText.text = displayString;

        // Resize and center the text element
        displayText.rectTransform.sizeDelta = new Vector2(1000f, 600f);
        displayText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        displayText.alignment = TextAnchor.MiddleCenter;

        cashDisplay.cash = (int)total;
    }

    private void HandleGameOverButtonClick()
    {
        if (cashDisplay.cash <= -1)
        {
            SceneManager.LoadScene("GameOver"); // Load the "GameOver" scene
        }
    }

}