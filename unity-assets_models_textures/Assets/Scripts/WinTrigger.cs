using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Timer otherTimer = other.GetComponent<Timer>();
        if (otherTimer != null)
            otherTimer.enabled = false;
    }
}