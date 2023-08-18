using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject winCanvas;
    public TMPro.TextMeshProUGUI finalTime;
    public Text TimerText;
    private float elapsedTime;

    private void Start()
    {
        // Reset the elapsed time
        elapsedTime = 0f;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);
        int milliseconds = (int)((elapsedTime * 100f) % 100f);

        TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
    public void Win(float finishTime)
    {
        elapsedTime = finishTime;
        if (winCanvas != null && finalTime != null)
        {
            finalTime.text = "Finish Time: " + elapsedTime.ToString("F2");
            TimerText.gameObject.SetActive(false);
        }
    }
}
