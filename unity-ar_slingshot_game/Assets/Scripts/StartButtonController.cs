using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    public GameObject startButton;

    void Start()
    {
        startButton.SetActive(false);
    }

    public void ShowStartButton()
    {
        startButton.SetActive(true);
    }

    public void HideStartButton()
    {
        startButton.SetActive(false);
    }
}