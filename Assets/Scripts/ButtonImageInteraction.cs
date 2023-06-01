using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageInteraction : MonoBehaviour
{
    public GameObject objectToSetActive;
    public Button buttonToActivate;
    public Button buttonToDisable;

    private void Start()
    {
        if (buttonToActivate != null)
        {
            buttonToActivate.onClick.AddListener(ActivateObject);
        }

        if (buttonToDisable != null)
        {
            buttonToDisable.onClick.AddListener(DisableObject);
        }
    }

    private void ActivateObject()
    {
        if (objectToSetActive != null)
        {
            objectToSetActive.SetActive(true);
        }
    }

    private void DisableObject()
    {
        if (objectToSetActive != null)
        {
            objectToSetActive.SetActive(false);
        }
    }
}
