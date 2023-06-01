using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject options;
    public GameObject Endday;
    
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If Canvas1 is active, disable it and enable Options
            if (canvas1.activeSelf)
            {
                canvas1.SetActive(false);
                options.SetActive(true);
            }
            // If Options is active, disable it and enable Canvas1
            else if (options.activeSelf)
            {
                canvas1.SetActive(true);
                options.SetActive(false);
            }
        }
    }

    public void ActivateEnddayCanvas()
    {
        canvas1.SetActive(false);
        options.SetActive(false);
        Endday.SetActive(true);
        
    }
}