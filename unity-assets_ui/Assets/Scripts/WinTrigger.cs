using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void OnTriggerEnter(Collider other)
    {
        Timer otherTimer = other.GetComponent<Timer>();
        if (otherTimer != null)
        {
            float finishTime = Time.time - startTime;
            otherTimer.Win(finishTime);
            if (winCanvas != null)
                winCanvas.SetActive(true);
        }
    }
}
