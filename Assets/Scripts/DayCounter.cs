using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public int day = 1;
    private Vector3 objectPosition;

    private void Start()
    {
        // Store the initial position of the object
        objectPosition = transform.position;
        day = 1;
    }

    private void OnGUI()
    {
        // Convert the object's position to screen coordinates
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);

        // Create a label style with desired font size, alignment, and font style
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 32;
        labelStyle.alignment = TextAnchor.MiddleCenter;
        labelStyle.fontStyle = FontStyle.Bold;

        // Create a rectangle centered around the object's position
        float labelWidth = 200f;
        float labelHeight = 40f;
        Rect labelRect = new Rect(screenPosition.x - (labelWidth / 2f), Screen.height - screenPosition.y, labelWidth, labelHeight);

        // Display the day number in the label rectangle
        GUI.Label(labelRect, "Day: " + day, labelStyle);
    }
}