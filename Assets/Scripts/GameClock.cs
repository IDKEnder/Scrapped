
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public static event System.Action OnTimeThresholdReached; // Static event
    public static event System.Action OnTimeReached;
    public GameObject objectToDeactivate;
    public CanvasController canvasController;
    public float currentTime = 0.0f;
    public float timeSpeed = 1.0f;
    public Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    public Color textColor = Color.white;

    private void Update()
    {
        currentTime += Time.deltaTime * timeSpeed;
        CheckTime();
    }

    void OnGUI()
    {
        // Define the font size and style for the timer text
        GUIStyle timerStyle = new GUIStyle(GUI.skin.label);
        timerStyle.fontSize = 32;
        timerStyle.fontStyle = FontStyle.Bold;
        timerStyle.normal.textColor = textColor;

        // Define the width and height of the timer display
        int timerWidth = 200;
        int timerHeight = 60;

        // Format the time string to display minutes and seconds
        string timeString = Mathf.FloorToInt(currentTime / 60.0f).ToString("00") + ":" + Mathf.FloorToInt(currentTime % 60.0f).ToString("00");

        // Get the screen position of the game object
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Create a Rect that is centered on the game object's screen position
        Rect timerRect = new Rect(screenPosition.x - (timerWidth / 2), Screen.height - screenPosition.y - (timerHeight / 2), timerWidth, timerHeight);

        // Display the timer text without a background color
        GUI.Label(timerRect, "Time: " + timeString, timerStyle);
    }

    private void CheckTime()
    {
        if (currentTime >= 120.0f && OnTimeThresholdReached != null) // 120.0f is 2:00 in seconds
        {
            OnTimeReached?.Invoke();
            OnTimeThresholdReached.Invoke(); // Invoke the event

            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false); // Deactivate the specified object
            }

            CanvasController canvasController = FindObjectOfType<CanvasController>();
            canvasController.ActivateEnddayCanvas();
        }
    }
}