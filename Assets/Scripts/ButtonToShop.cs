using UnityEngine.UI;
using UnityEngine;

public class ButtonToShop : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas enddayCanvas;
    public Canvas Shop;


    private void Start()
    {
        // Attach the button click event to the HandleClick method
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    public void HandleClick()
    {
        SetActiveCanvas();
        
    }

    private void SetActiveCanvas()
    {
        
        if (canvas1 != null)
        {
            canvas1.gameObject.SetActive(false);
        }

        if (enddayCanvas != null)
        {
            enddayCanvas.gameObject.SetActive(false);
        }

        if (Shop != null)
        {
            Shop.gameObject.SetActive(true);
        }
    }
}
