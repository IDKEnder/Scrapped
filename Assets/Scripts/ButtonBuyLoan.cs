using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonBuyLoan : MonoBehaviour
{
    public CashDisplay Cash;
    public ChangeScene SM;


    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Update);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cash.cash >= 1000000)
        {
            SM.MoveToScene(8);         
        }
    }
}
