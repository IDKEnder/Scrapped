using UnityEngine.UI;
using UnityEngine;

public class Button2xMoney : MonoBehaviour
{
    public CashDisplay CD;
    public DisplayShipment displayShipment;

    [SerializeField]
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    void HandleClick()
    {
        if (CD.cash >= 5200)
        {
            CD.cash = CD.cash - 5200;
            displayShipment.Doubled = true;
            button.interactable = false;
        }
    }
}
