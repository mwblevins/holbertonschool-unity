using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float elapsedTime;

    private void Start()
    {
        // Reset the elapsed time
        elapsedTime = 0f;
    }

    void OnDisable()
    {
        TimerText.color = Color.green;
        TimerText.fontSize = 80;
    }

    private void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate minutes, seconds, and milliseconds
        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);
        int milliseconds = (int)((elapsedTime * 100f) % 100f);

        // Update the TimerText object with the formatted time
        TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
