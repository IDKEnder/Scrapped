using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject options;

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

    public void ActivateEnddayCanvas()
    {
        canvas1.SetActive(false);

        // Destroy all child objects of options
        foreach (Transform child in options.transform)
        {
            Destroy(child.gameObject);
        }

        // Destroy all child objects of Endday
        foreach (Transform child in Endday.transform)
        {
            Destroy(child.gameObject);
        }

        options.SetActive(false);
        Endday.SetActive(true);
    }
    public void NextDay()
    {
        options.SetActive(false);
        Endday.SetActive(false);
        canvas1.SetActive(true);
    }
=======
>>>>>>> parent of fe8421d (Update 29/04/23)
=======
>>>>>>> parent of fe8421d (Update 29/04/23)
=======
>>>>>>> parent of fe8421d (Update 29/04/23)
}