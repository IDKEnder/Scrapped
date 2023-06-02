using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cash.cash >= 1000000)
        {
            MoveToScene(8);
        }
    }
}
