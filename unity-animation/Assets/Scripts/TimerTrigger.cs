using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Timer timerScript;
    private bool timerStarted;

    private void Start()
    {
        timerScript = FindObjectOfType<Timer>();
        timerStarted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerStarted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (timerStarted && timerScript != null) // Add a null check for timerScript
            {
                timerScript.enabled = true;
            }
        }
    }
}

