using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonBoots : MonoBehaviour
{
    public PlayerMovement PM;
    public CashDisplay CD;

    private void Start()
    {
        // Attach the button click event to the HandleClick method
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

        if (temp <= 100000)
        {
            temp = CD.cash - 100000;
            PM.moveSpeed = 6f;
        }
    }
}
