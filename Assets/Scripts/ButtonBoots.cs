using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonBoots : MonoBehaviour
{
    public PlayerMovement PM;
    public CashDisplay CD;

    [SerializeField]
    private Button button;

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
        if (CD.cash >= 3000)
        {
            CD.cash = CD.cash - 3000;
            PM.moveSpeed = 6f;
            button.interactable = false;
        }
    }
}
