using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBuyLoan : MonoBehaviour
{
    public CashDisplay Cash;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    void HandleClick()
    {
        if (Cash.cash >= 1000000)
        {
            SceneManager.LoadScene("Victory"); // Load the "Victory" scene
        }
    }
}
