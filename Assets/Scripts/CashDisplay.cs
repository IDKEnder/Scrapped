using UnityEngine;

public class CashDisplay : MonoBehaviour
{
    public int cash = 0; // public variable to hold the cash amount

    private GUIStyle cashTextStyle; // private GUI style for the cash text

    void Start()
    {
        // create a new GUI style for the cash text
        cashTextStyle = new GUIStyle();
        cashTextStyle.fontSize = 32;
        cashTextStyle.fontStyle = FontStyle.Bold;
        cashTextStyle.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        // Calculate the position of the game object in screen space
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);

        // display the cash amount as a label at the game object's position using the GUI layout system
        GUI.Label(new Rect(position.x, Screen.height - position.y, 200, 30), "Cash: " + cash.ToString(), cashTextStyle);
    }

}
