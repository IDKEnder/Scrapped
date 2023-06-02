using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    public GameClock gameClock;
    public Canvas canvas1;
    public Canvas optionsCanvas;
    public Canvas enddayCanvas;
    public Canvas Shop;
    public DisplayShipment displayShipment;
    public Shipment shipment;
    public RawMaterialSpawner rawMaterialSpawner;
    public DayCounter dayCounter;
    public CashDisplay cashDisplay;

    [SerializeField]
    private int deductionAmount = 100; // Adjust the deduction amount here
    [SerializeField]
    private int gameOverScene; // Scene to switch

    private void Start()
    {
        // Attach the button click event to the HandleClick method
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    public void HandleClick()
    {
        IncrementDays();
        SetActiveCanvas();
        UpdateCash();
        ResetTotal();
        ResetSpawnCountAndLimit();
        ResetShipmentVariables();
    }

    private void IncrementDays()
    {
        gameClock.currentTime = 0.0f; // Reset the current time to 0.0f
        dayCounter.day++;
    }

    private void SetActiveCanvas()
    {
        if (enddayCanvas != null)
        {
            enddayCanvas.gameObject.SetActive(false);
        }

        if (optionsCanvas != null && optionsCanvas.gameObject.activeSelf)
        {
            optionsCanvas.gameObject.SetActive(false);
        }

        if (canvas1 != null)
        {
            canvas1.gameObject.SetActive(true);
        }

        if(Shop != null)
        {
            Shop.gameObject.SetActive(true);
        }
    }

    private void ResetTotal()
    {
        if (displayShipment != null)
        {
            displayShipment.total = 0f;
        }
    }

    private void ResetSpawnCountAndLimit()
    {
        if (rawMaterialSpawner != null)
        {
            rawMaterialSpawner.spawnCount = 0;
            rawMaterialSpawner.spawnLimit += 2;
        }
    }

    private void ResetShipmentVariables()
    {
        if (shipment != null)
        {
            shipment.Bottle = 0;
            shipment.DoubleBottle = 0;
            shipment.TripleBottle = 0;
            shipment.GoldenBottle = 0;
            shipment.BrokenBottle = 0;
        }
    }

    private void UpdateCash()
    {
        if (displayShipment != null && cashDisplay != null)
        {
            int adjustedDeductionAmount = deductionAmount; // Assign the serialized deductionAmount to a local variable
            int deductedTotal = (int)displayShipment.total - adjustedDeductionAmount; // Deduct the adjustedDeductionAmount from total
            cashDisplay.cash = deductedTotal; // Update cashDisplay.cash with the deducted total

            if (deductedTotal < 0)
            {
               SceneManager.LoadScene(gameOverScene);
            }
        }
    }
}
