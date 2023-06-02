using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Button2xMoney : MonoBehaviour
{
    public CashDisplay CD;
    public DisplayShipment DS;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    void HandleClick()
    {
        rasly();
    }

    void rasly()
    {
        int temp = CD.cash;

        if (temp <= 550000)
        {
            temp = CD.cash - 550000;
            
        }
    }
}
