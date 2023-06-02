using UnityEngine.UI;
using UnityEngine;

public class Button2xMoney : MonoBehaviour
{
    public CashDisplay CD;
    public DisplayShipment displayShipment;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    void HandleClick()
    {
        displayShipment.Doubled = true;
    }
}
