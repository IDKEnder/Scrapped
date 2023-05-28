using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public void ClearSlot()
    {
        icon.enabled = false;
    }

    public void DrawSlot(Items items)
    {
        if (items == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;

        icon.sprite = items.Items.icon;
    }
}